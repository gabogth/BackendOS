using Microsoft.Extensions.Logging;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;
using nest.core.dominio.Security.Tenant;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaServices
{
    public class RegistroAsistenciaService
    {
        protected readonly IRegistroAsistenciaRepository repository;
        protected readonly IHorarioRepository horarioRepository;
        protected readonly IPersonalRepository personalRepository;
        protected readonly IHorarioDetalleRepository horarioDetalleRepository;
        protected readonly IConnectionStringService connectionStringService;

        public RegistroAsistenciaService(IRegistroAsistenciaRepository repository, IHorarioRepository horarioRepository, IPersonalRepository personalRepository, IHorarioDetalleRepository horarioDetalleRepository, IConnectionStringService connectionStringService)
        {
            this.repository = repository;
            this.horarioRepository = horarioRepository;
            this.personalRepository = personalRepository;
            this.horarioDetalleRepository = horarioDetalleRepository;
            this.connectionStringService = connectionStringService;
        }

        public Task<RegistroAsistencia> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<RegistroAsistencia>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<RegistroAsistencia>> BuscarPorRangoFecha(int personalId, DateTime fechaInicio, DateTime fechaFin) => repository.BuscarPorRangoFecha(personalId, fechaInicio, fechaFin);
        public virtual async Task<RegistroAsistencia> AgregarUsuarioActual(RegistroAsistenciaCrearDto entry)
        {
            entry.EmpresaId = connectionStringService.EmpresaId.HasValue ? connectionStringService.EmpresaId.Value : throw new Exception("Usuario no autenticado");
            entry.PersonalId = int.Parse(connectionStringService.UserId);
            entry.Fecha = DateTime.Now;
            return await Agregar(entry);
        }
        public virtual async Task<RegistroAsistencia> Agregar(RegistroAsistenciaCrearDto entry)
        {
            entry = await GetRegistroAsistencia(entry);
            return await repository.Agregar(entry);
        }
        public virtual Task<RegistroAsistencia> Modificar(long id, RegistroAsistenciaCrearDto entry) => repository.Modificar(id, entry);
        public virtual Task Eliminar(long id) => repository.Eliminar(id);
        protected virtual async Task<RegistroAsistenciaCrearDto> GetRegistroAsistencia(RegistroAsistenciaCrearDto registro)
        {
            RegistroAsistencia ultimaMarca = await this.repository.BuscarUltimaMarca(registro.PersonalId);
            if (ultimaMarca != null)
            {
                double minutosUltimaMarca = registro.Fecha.Subtract(ultimaMarca.Fecha).TotalMinutes;
                double minutosThreshold = 10;
                if (minutosUltimaMarca <= minutosThreshold)
                    throw new Exception($"Marca reciente, puedes volverlo a intentar en {Math.Round(minutosThreshold - minutosUltimaMarca, 2)} minutos.");
            }
            HorarioCabecera horario = await this.horarioRepository.ObtenerPorPersonalId(registro.PersonalId);
            RegistroAsistenciaPolitica politica = (await this.personalRepository.ObtenerPorId(registro.PersonalId)).RegistroAsistenciaPolitica;
            JornalParams? jornalActual = GetDiaLaboral(horario, registro.Fecha);
            if (jornalActual != null)
            {
                RegistroAsistencia entrada = await repository.BuscarPorRangoFecha(registro.PersonalId, jornalActual.FechaEntradaConRango, jornalActual.FechaSalidaConRango, HorarioDetalleEventoTipoEnum.Entrada);
                if (entrada == null)
                {
                    registro.TipoEvento = HorarioDetalleEventoTipoEnum.Entrada;
                    registro.FechaJornal = DateOnly.FromDateTime(jornalActual.FechaEntrada);
                    registro.DiferenciaMinutos = (int)Math.Ceiling(registro.Fecha.Subtract(jornalActual.FechaEntrada).TotalMinutes);
                    registro.EsTardanza = registro.DiferenciaMinutos > politica.MinutosTardanzaIngreso;
                    registro.HorarioDetalleEventoId = jornalActual.Evento.Id;
                    registro.RegistroAsistenciaPoliticaId = politica.Id;
                }
                else
                {
                    (HorarioDetalleEvento, DateTime)? evento = await GetMarca(entrada.HorarioDetalleEventoId.Value, entrada.FechaJornal, registro.Fecha);
                    if (evento.HasValue)
                    {
                        registro.TipoEvento = evento.Value.Item1.TipoEvento;
                        registro.FechaJornal = entrada.FechaJornal;
                        registro.DiferenciaMinutos = (int)Math.Ceiling(registro.Fecha.Subtract(evento.Value.Item2).TotalMinutes);
                        registro.EsTardanza = false;
                        registro.HorarioDetalleEventoId = evento.Value.Item1.Id;
                        registro.RegistroAsistenciaPoliticaId = politica.Id;
                    }
                    else
                    {
                        registro.TipoEvento = HorarioDetalleEventoTipoEnum.Otros;
                        registro.FechaJornal = entrada.FechaJornal;
                        registro.DiferenciaMinutos = 0;
                        registro.EsTardanza = false;
                        registro.HorarioDetalleEventoId = null;
                        registro.RegistroAsistenciaPoliticaId = politica.Id;
                    }
                }
                return registro;
            }
            else throw new Exception("FUERA DE HORA");
        }

        public virtual async Task<(HorarioDetalleEvento, DateTime)?> GetMarca(long MarcaEntradaId, DateOnly fechaJornal, DateTime fechaRegistro)
        {
            HorarioDetalle? detalle = await horarioDetalleRepository.ObtenerPorId(MarcaEntradaId);
            foreach (HorarioDetalleEvento hde in detalle.HorarioDetalleEventos)
            {
                DateTime fecha = fechaJornal.AddDays(hde.DiferenciaDia).ToDateTime(hde.Hora);
                DateTime fechaVentanaMin = fecha.AddMinutes(hde.VentanaMin);
                DateTime fechaVentanaMax = fecha.AddMinutes(hde.VentanaMax);
                if (fechaVentanaMin <= fechaRegistro && fechaVentanaMax >= fechaRegistro)
                    return (hde, fecha);
            }
            return null;
        }

        private JornalParams? GetDiaLaboral(HorarioCabecera horario, DateTime fechaRegistro)
        {
            List<JornalParams> paramsx = new List<JornalParams>();
            paramsx.Add(GetParamsJornal(horario, DayOfWeekUtils.Ayer(fechaRegistro.DayOfWeek), fechaRegistro.AddDays(-1)));
            paramsx.Add(GetParamsJornal(horario, fechaRegistro.DayOfWeek, fechaRegistro));
            paramsx.Add(GetParamsJornal(horario, DayOfWeekUtils.Manana(fechaRegistro.DayOfWeek), fechaRegistro.AddDays(1)));
            foreach (JornalParams parametro in paramsx)
            {
                if (parametro.FechaEntradaConRango <= fechaRegistro && parametro.FechaSalidaConRango >= fechaRegistro)
                    return parametro;
            }
            return null;
        }

        private JornalParams GetParamsJornal(HorarioCabecera horario, DayOfWeek Dia, DateTime fecha)
        {
            HorarioDetalle? horarioDetalle = horario.HorarioDetalles.Where(x => x.DiaSemana == Dia).FirstOrDefault();
            DateOnly fechaErr = DateOnly.FromDateTime(fecha);
            (HorarioDetalleEvento?, HorarioDetalleEvento?) jornal = (
                horarioDetalle.HorarioDetalleEventos.Where(x => x.TipoEvento == HorarioDetalleEventoTipoEnum.Entrada).FirstOrDefault(),
                horarioDetalle.HorarioDetalleEventos.Where(x => x.TipoEvento == HorarioDetalleEventoTipoEnum.Salida).FirstOrDefault()
            );
            return new JornalParams
            {
                FechaEntrada = fechaErr.AddDays(jornal.Item1.DiferenciaDia).ToDateTime(jornal.Item1.Hora, DateTimeKind.Local),
                FechaSalida = fechaErr.AddDays(jornal.Item2.DiferenciaDia).ToDateTime(jornal.Item2.Hora, DateTimeKind.Local),
                FechaEntradaConRango = fechaErr.AddDays(jornal.Item1.DiferenciaDia).ToDateTime(jornal.Item1.Hora, DateTimeKind.Local).AddMinutes(-Math.Abs(jornal.Item1.VentanaMin)),
                FechaSalidaConRango = fechaErr.AddDays(jornal.Item2.DiferenciaDia).ToDateTime(jornal.Item2.Hora, DateTimeKind.Local).AddMinutes(Math.Abs(jornal.Item1.VentanaMax)),
                Evento = jornal.Item1
            };
        }

        private bool FechaEnRango(DateTime FechaRef, DateTime RangeMin, DateTime RangeMax)
        {
            return RangeMin <= FechaRef && FechaRef <= RangeMax;
        }

        private bool FechaEnRango(DateTime FechaRef, DateTime FechaBase, int VentanaMin, int VentanaMax)
        {
            return FechaEnRango(FechaRef, FechaBase.AddMinutes(-Math.Abs(VentanaMin)), FechaBase.AddMinutes(Math.Abs(VentanaMax)));
        }

        private class JornalParams
        {
            public DateTime FechaEntrada { get; set; }
            public DateTime FechaSalida { get; set; }
            public DateTime FechaEntradaConRango { get; set; }
            public DateTime FechaSalidaConRango { get; set; }
            public HorarioDetalleEvento Evento { get; set; }
        }
    }
}
