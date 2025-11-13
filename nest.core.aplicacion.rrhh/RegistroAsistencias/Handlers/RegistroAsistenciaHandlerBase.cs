using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    public abstract class RegistroAsistenciaHandlerBase
    {
        protected readonly IRegistroAsistenciaRepository repository;
        protected readonly IHorarioRepository horarioRepository;
        protected readonly IPersonalRepository personalRepository;
        protected readonly IHorarioDetalleRepository horarioDetalleRepository;

        protected RegistroAsistenciaHandlerBase(
            IRegistroAsistenciaRepository repository,
            IHorarioRepository horarioRepository,
            IPersonalRepository personalRepository,
            IHorarioDetalleRepository horarioDetalleRepository)
        {
            this.repository = repository;
            this.horarioRepository = horarioRepository;
            this.personalRepository = personalRepository;
            this.horarioDetalleRepository = horarioDetalleRepository;
        }

        protected async Task<RegistroAsistencia> PrepararRegistroAsync(RegistroAsistencia registro, HorarioCabecera horario)
        {
            var ultimaMarca = await repository.BuscarUltimaMarca(registro.PersonalId);
            if (ultimaMarca != null)
            {
                double minutosUltimaMarca = registro.Fecha.Subtract(ultimaMarca.Fecha).TotalMinutes;
                const double minutosThreshold = 10;
                if (minutosUltimaMarca <= minutosThreshold)
                {
                    throw new Exception($"Marca reciente, puedes volverlo a intentar en {Math.Round(minutosThreshold - minutosUltimaMarca, 2)} minutos.");
                }
            }

            var politica = (await personalRepository.ObtenerPorId(registro.PersonalId)).RegistroAsistenciaPolitica;
            var jornal = GetDiaLaboral(horario, registro.Fecha);

            if (jornal == null) //  Sin coincidencia de fechas
            {
                //throw new Exception("FUERA DE HORA");
                registro.TipoEvento = HorarioDetalleEventoTipoEnum.Otros;
                registro.FechaJornal = new DateOnly(1900, 1, 1);
                registro.DiferenciaMinutos = 0;
                registro.EsTardanza = false;
                registro.HorarioDetalleEventoId = null;
                registro.RegistroAsistenciaPoliticaId = null;
            }
            else
            {
                (HorarioDetalleEvento? evento, DateTime FechaEvento) = ObtenerEvento(jornal, registro.Fecha);
                if (evento == null)
                {
                    registro.TipoEvento = HorarioDetalleEventoTipoEnum.Otros;
                    registro.FechaJornal = DateOnly.FromDateTime(jornal.FechaEntrada);
                    registro.DiferenciaMinutos = 0;
                    registro.EsTardanza = false;
                    registro.HorarioDetalleEventoId = null;
                    registro.RegistroAsistenciaPoliticaId = null;
                }
                else
                {
                    int diffMinutos = (int)Math.Ceiling(registro.Fecha.Subtract(FechaEvento).TotalMinutes);
                    registro.TipoEvento = evento.TipoEvento;
                    registro.FechaJornal = DateOnly.FromDateTime(jornal.FechaEntrada);
                    registro.DiferenciaMinutos = diffMinutos;
                    registro.EsTardanza = false;
                    registro.HorarioDetalleEventoId = evento.Id;
                    registro.RegistroAsistenciaPoliticaId = politica.Id;
                }
            }
            return registro;
        }

        protected (HorarioDetalleEvento?, DateTime) ObtenerEvento(JornalParams jornal, DateTime fecha)
        {
            DateTime fechaReferencia = jornal.FechaEntrada.Date;
            HorarioDetalleEvento? evento = jornal.Detalle.HorarioDetalleEventos.Where(x =>
            {
                DateTime rangoInicial = fechaReferencia.AddDays(x.DiferenciaDia).Add(x.Hora.ToTimeSpan()).AddMinutes(-Math.Abs(x.VentanaMin));
                DateTime rangoFinal = fechaReferencia.AddDays(x.DiferenciaDia).Add(x.Hora.ToTimeSpan()).AddMinutes(Math.Abs(x.VentanaMax));
                return rangoInicial <= fecha && rangoFinal >= fecha;
            }).FirstOrDefault();
            if (evento != null)
                return (evento, fechaReferencia.AddDays(evento.DiferenciaDia).Add(evento.Hora.ToTimeSpan()));
            else
                return (null, DateTime.Now);
        }

        private JornalParams? GetDiaLaboral(HorarioCabecera horario, DateTime fechaRegistro)
        {
            var parametros = new List<JornalParams>();
            JornalParams ayer = GetParamsJornal(horario, DayOfWeekUtils.Ayer(fechaRegistro.DayOfWeek), fechaRegistro.AddDays(-1));
            JornalParams hoy = GetParamsJornal(horario, fechaRegistro.DayOfWeek, fechaRegistro);
            JornalParams manana = GetParamsJornal(horario, DayOfWeekUtils.Manana(fechaRegistro.DayOfWeek), fechaRegistro.AddDays(1));
            if (ayer != null) parametros.Add(ayer);
            if (hoy != null) parametros.Add(hoy);
            if (manana != null) parametros.Add(manana);

            return parametros.FirstOrDefault(p => p.FechaEntradaConRango <= fechaRegistro && p.FechaSalidaConRango >= fechaRegistro);
        }

        private JornalParams GetParamsJornal(HorarioCabecera horario, DayOfWeek dia, DateTime fecha)
        {
            var detalle = horario.HorarioDetalles.FirstOrDefault(x => x.DiaSemana == dia);
            if (detalle == null)
                return null;

            var eventos = (
                detalle.HorarioDetalleEventos.FirstOrDefault(x => x.TipoEvento == HorarioDetalleEventoTipoEnum.Entrada),
                detalle.HorarioDetalleEventos.FirstOrDefault(x => x.TipoEvento == HorarioDetalleEventoTipoEnum.Salida)
            );

            if (eventos.Item1 is null || eventos.Item2 is null)
            {
                throw new Exception("El detalle de horario no tiene eventos de entrada y salida configurados.");
            }

            var fechaBase = DateOnly.FromDateTime(fecha);
            return new JornalParams
            {
                FechaEntrada = fechaBase.AddDays(eventos.Item1.DiferenciaDia).ToDateTime(eventos.Item1.Hora, DateTimeKind.Local),
                FechaSalida = fechaBase.AddDays(eventos.Item2.DiferenciaDia).ToDateTime(eventos.Item2.Hora, DateTimeKind.Local),
                FechaEntradaConRango = fechaBase.AddDays(eventos.Item1.DiferenciaDia).ToDateTime(eventos.Item1.Hora, DateTimeKind.Local).AddMinutes(-Math.Abs(eventos.Item1.VentanaMin)),
                FechaSalidaConRango = fechaBase.AddDays(eventos.Item2.DiferenciaDia).ToDateTime(eventos.Item2.Hora, DateTimeKind.Local).AddMinutes(Math.Abs(eventos.Item2.VentanaMax)),
                Evento = eventos.Item1,
                Detalle = detalle
            };
        }

        protected record JornalParams
        {
            public DateTime FechaEntrada { get; init; }
            public DateTime FechaSalida { get; init; }
            public DateTime FechaEntradaConRango { get; init; }
            public DateTime FechaSalidaConRango { get; init; }
            public HorarioDetalleEvento Evento { get; init; }
            public HorarioDetalle Detalle { get; init; }
        }
    }
}
