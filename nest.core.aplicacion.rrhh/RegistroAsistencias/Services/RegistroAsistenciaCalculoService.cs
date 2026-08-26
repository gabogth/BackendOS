using nest.core.aplicacion.rrhh.RegistroAsistencias.Services.Interface;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Services
{
    public class RegistroAsistenciaCalculoService : IMarcacionCalculoService
    {
        protected readonly IRegistroAsistenciaRepository repository;
        protected readonly IHorarioRepository horarioRepository;
        protected readonly IPersonalRepository personalRepository;
        protected readonly IHorarioDetalleRepository horarioDetalleRepository;
        protected readonly IOrdenTrabajoHorarioRepository ordenTrabajoHorarioRepository;

        public RegistroAsistenciaCalculoService(
            IRegistroAsistenciaRepository repository,
            IHorarioRepository horarioRepository,
            IPersonalRepository personalRepository,
            IHorarioDetalleRepository horarioDetalleRepository,
            IOrdenTrabajoHorarioRepository ordenTrabajoHorarioRepository)
        {
            this.repository = repository;
            this.horarioRepository = horarioRepository;
            this.personalRepository = personalRepository;
            this.horarioDetalleRepository = horarioDetalleRepository;
            this.ordenTrabajoHorarioRepository = ordenTrabajoHorarioRepository;
        }

        public async Task<ResultadoCalculoOrdenTrabajo> PrepararRegistroOrdenTrabajoAsync(RegistroAsistencia registro)
        {
            var personal = await personalRepository.ObtenerPorId(registro.PersonalId)
                ?? throw new InvalidOperationException($"No existe el personal con Id {registro.PersonalId}.");
            var candidatos = await ordenTrabajoHorarioRepository
                .ObtenerCandidatosPorPersonalYFecha(registro.PersonalId, registro.Fecha);
            var otHorario = ResolverOrdenTrabajo(candidatos, registro.Fecha);
            var horarioActual = otHorario?.HorarioCabecera ?? personal.HorarioCabecera
                ?? throw new InvalidOperationException($"El personal con Id {registro.PersonalId} no tiene un horario aplicable.");

            var registroPreparado = await PrepararRegistroAsync(registro, horarioActual, otHorario?.Fecha, personal);
            return new ResultadoCalculoOrdenTrabajo(registroPreparado, otHorario);
        }

        private static OrdenTrabajoHorario? ResolverOrdenTrabajo(IEnumerable<OrdenTrabajoHorario> candidatos, DateTime fechaMarcacion)
        {
            return candidatos
                .Select(x => (Asignacion: x, Jornal: CrearJornal(x.HorarioCabecera, x.Fecha)))
                .Where(x => Contiene(x.Jornal, fechaMarcacion))
                .Select(x =>
                {
                    var evento = ObtenerEvento(x.Jornal, fechaMarcacion);
                    return new
                    {
                        x.Asignacion,
                        CoincideEvento = evento.Evento != null,
                        DistanciaEvento = evento.Evento == null
                            ? double.MaxValue
                            : Math.Abs(fechaMarcacion.Subtract(evento.FechaEvento).TotalMinutes)
                    };
                })
                .OrderByDescending(x => x.CoincideEvento)
                .ThenBy(x => x.DistanciaEvento)
                .ThenByDescending(x => x.Asignacion.Fecha)
                .ThenByDescending(x => x.Asignacion.Id)
                .Select(x => x.Asignacion)
                .FirstOrDefault();
        }

        public async Task<RegistroAsistencia> PrepararRegistroAsync(
            RegistroAsistencia registro,
            HorarioCabecera horario,
            DateOnly? fechaBase = null)
        {
            var personal = await personalRepository.ObtenerPorId(registro.PersonalId)
                ?? throw new InvalidOperationException($"No existe el personal con Id {registro.PersonalId}.");
            return await PrepararRegistroAsync(registro, horario, fechaBase, personal);
        }

        private async Task<RegistroAsistencia> PrepararRegistroAsync(
            RegistroAsistencia registro,
            HorarioCabecera horario,
            DateOnly? fechaBase,
            Personal personal)
        {
            if (horario == null)
                throw new InvalidOperationException("No existe un horario aplicable para registrar la asistencia.");

            var ultimaMarca = await repository.BuscarUltimaMarca(registro.PersonalId);
            if (ultimaMarca != null)
            {
                double minutosUltimaMarca = Math.Abs(registro.Fecha.Subtract(ultimaMarca.Fecha).TotalMinutes);
                const double minutosThreshold = 10;
                if (minutosUltimaMarca <= minutosThreshold)
                    throw new Exception($"Marca reciente, puedes volverlo a intentar en {Math.Round(minutosThreshold - minutosUltimaMarca, 2)} minutos.");
            }

            var politica = personal.RegistroAsistenciaPolitica;
            var jornal = fechaBase.HasValue
                ? CrearJornal(horario, fechaBase.Value)
                : GetDiaLaboral(horario, registro.Fecha);

            if (jornal == null || !Contiene(jornal, registro.Fecha))
            {
                registro.TipoEvento = HorarioDetalleEventoTipoEnum.Otros;
                registro.FechaJornal = DateOnly.FromDateTime(registro.Fecha);
                registro.DiferenciaMinutos = 0;
                registro.EsTardanza = false;
                registro.HorarioDetalleEventoId = null;
                registro.RegistroAsistenciaPoliticaId = null;
                return registro;
            }

            var (evento, fechaEvento) = ObtenerEvento(jornal, registro.Fecha);
            registro.FechaJornal = jornal.FechaBase;
            if (evento == null)
            {
                registro.TipoEvento = HorarioDetalleEventoTipoEnum.Otros;
                registro.DiferenciaMinutos = 0;
                registro.EsTardanza = false;
                registro.HorarioDetalleEventoId = null;
                registro.RegistroAsistenciaPoliticaId = null;
            }
            else
            {
                registro.TipoEvento = evento.TipoEvento;
                registro.DiferenciaMinutos = (int)Math.Ceiling(registro.Fecha.Subtract(fechaEvento).TotalMinutes);
                registro.EsTardanza = false;
                registro.HorarioDetalleEventoId = evento.Id;
                registro.RegistroAsistenciaPoliticaId = politica?.Id;
            }
            return registro;
        }

        private static (HorarioDetalleEvento? Evento, DateTime FechaEvento) ObtenerEvento(JornalParams jornal, DateTime fecha)
        {
            var coincidencias = jornal.Detalle.HorarioDetalleEventos
                .Select(evento => (Evento: evento, FechaEvento: FechaEvento(jornal.FechaBase, evento)))
                .Where(x => x.FechaEvento.AddMinutes(-Math.Abs(x.Evento.VentanaMin)) <= fecha
                    && x.FechaEvento.AddMinutes(Math.Abs(x.Evento.VentanaMax)) >= fecha)
                .OrderBy(x => Math.Abs(fecha.Subtract(x.FechaEvento).TotalMinutes))
                .ThenBy(x => x.Evento.Id)
                .ToList();

            return coincidencias.Count == 0 ? (null, default) : coincidencias[0];
        }

        private static JornalParams? GetDiaLaboral(HorarioCabecera horario, DateTime fechaRegistro)
        {
            if (horario == null)
                throw new InvalidOperationException("No existe un horario aplicable para registrar la asistencia.");

            var fecha = DateOnly.FromDateTime(fechaRegistro);
            var jornadas = new[] { fecha.AddDays(-1), fecha, fecha.AddDays(1) }
                .Select(x => CrearJornalOpcional(horario, x))
                .Where(x => x != null)
                .Cast<JornalParams>();

            return jornadas
                .Where(x => Contiene(x, fechaRegistro))
                .OrderByDescending(x => ObtenerEvento(x, fechaRegistro).Evento != null)
                .ThenBy(x =>
                {
                    var evento = ObtenerEvento(x, fechaRegistro);
                    return evento.Evento == null ? double.MaxValue : Math.Abs(fechaRegistro.Subtract(evento.FechaEvento).TotalMinutes);
                })
                .ThenByDescending(x => x.FechaBase)
                .FirstOrDefault();
        }

        private static JornalParams CrearJornal(HorarioCabecera horario, DateOnly fechaBase)
        {
            return CrearJornalOpcional(horario, fechaBase)
                ?? throw new InvalidOperationException($"El horario no tiene un detalle configurado para {fechaBase.DayOfWeek} ({fechaBase:yyyy-MM-dd}).");
        }

        private static JornalParams? CrearJornalOpcional(HorarioCabecera horario, DateOnly fechaBase)
        {
            var detalle = horario?.HorarioDetalles?.FirstOrDefault(x => x.DiaSemana == fechaBase.DayOfWeek);
            if (detalle == null)
                return null;

            var entrada = detalle.HorarioDetalleEventos?.FirstOrDefault(x => x.TipoEvento == HorarioDetalleEventoTipoEnum.Entrada);
            var salida = detalle.HorarioDetalleEventos?.FirstOrDefault(x => x.TipoEvento == HorarioDetalleEventoTipoEnum.Salida);
            if (entrada == null || salida == null)
                throw new InvalidOperationException($"El detalle de horario del {fechaBase.DayOfWeek} debe tener eventos de entrada y salida configurados.");

            return new JornalParams
            {
                FechaBase = fechaBase,
                FechaEntradaConRango = FechaEvento(fechaBase, entrada).AddMinutes(-Math.Abs(entrada.VentanaMin)),
                FechaSalidaConRango = FechaEvento(fechaBase, salida).AddMinutes(Math.Abs(salida.VentanaMax)),
                Detalle = detalle
            };
        }

        private static DateTime FechaEvento(DateOnly fechaBase, HorarioDetalleEvento evento) =>
            fechaBase.AddDays(evento.DiferenciaDia).ToDateTime(evento.Hora, DateTimeKind.Local);

        private static bool Contiene(JornalParams jornal, DateTime fecha) =>
            jornal.FechaEntradaConRango <= fecha && jornal.FechaSalidaConRango >= fecha;

        private sealed record JornalParams
        {
            public DateOnly FechaBase { get; init; }
            public DateTime FechaEntradaConRango { get; init; }
            public DateTime FechaSalidaConRango { get; init; }
            public HorarioDetalle Detalle { get; init; } = null!;
        }
    }
}
