using Microsoft.Extensions.Logging;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using System.Linq;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaServices
{
    public class RegistroAsistenciaService
    {
        private readonly IRegistroAsistenciaRepository repository;
        private readonly IHorarioRepository horarioRepository;
        private readonly IPersonalRepository personalRepository;
        private readonly ILogger<RegistroAsistenciaService> logger;

        public RegistroAsistenciaService(IRegistroAsistenciaRepository repository, IHorarioRepository horarioRepository, IPersonalRepository personalRepository, ILogger<RegistroAsistenciaService> logger)
        {
            this.repository = repository;
            this.horarioRepository = horarioRepository;
            this.personalRepository = personalRepository;
            this.logger = logger;
        }

        public Task<RegistroAsistencia> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<RegistroAsistencia>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<RegistroAsistencia>> BuscarPorRangoFecha(int personalId, DateTime fechaInicio, DateTime fechaFin) => repository.BuscarPorRangoFecha(personalId, fechaInicio, fechaFin);
        public Task<RegistroAsistencia> Agregar(RegistroAsistenciaCrearDto entry) => repository.Agregar(entry);
        public Task<RegistroAsistencia> Modificar(long id, RegistroAsistenciaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
        public async Task GetGrupoHorario(RegistroAsistenciaCrearDto registro)
        {
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
                    registro.DiferenciaMinutos = registro.Fecha.Subtract(jornalActual.FechaEntrada).Minutes;
                    registro.EsTardanza = registro.DiferenciaMinutos > politica.MinutosTardanzaIngreso;
                    registro.HorarioDetalleEventoId = jornalActual.Evento.Id;
                    registro.RegistroAsistenciaPoliticaId = politica.Id;
                }
                else
                {
                    
                }

            }
            else throw new Exception("FUERA DE HORA");
        }

        //public (DateTime, HorarioDetalleEvento)? GetMarca(HorarioDetalleEvento horario, DateTime fechaJornal, DateTime fechaRegistro)
        //{
        //    List<(DateTime, HorarioDetalleEvento)> values = new List<(DateTime, HorarioDetalleEvento)>();
        //    try
        //    {

        //        foreach (HorarioDetalleEvento hde in ayer.HorarioDetalleEventos)
        //        {
        //            DateTime fecha = fechaAyerErr.AddDays(hde.DiferenciaDia).ToDateTime(hde.Hora);
        //            values.Add((fecha, hde));
        //        }

        //        return values.Where(x => FechaEnRango(fechaRegistro, x.Item1, x.Item2.VentanaMin, x.Item2.VentanaMax)).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.LogError("No hay un horario asignado");
        //        return null;
        //    }
        //}

        public JornalParams? GetDiaLaboral(HorarioCabecera horario, DateTime fechaRegistro)
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

        public JornalParams GetParamsJornal(HorarioCabecera horario, DayOfWeek Dia, DateTime fecha)
        {
            HorarioDetalle? horarioDetalle = horario.HorarioDetalles.Where(x => x.DiaSemana == Dia).FirstOrDefault();
            DateOnly fechaErr = DateOnly.FromDateTime(fecha.AddDays(-1));
            (HorarioDetalleEvento?, HorarioDetalleEvento?) jornal = (
                horarioDetalle.HorarioDetalleEventos.Where(x => x.TipoEvento == HorarioDetalleEventoTipoEnum.Entrada).FirstOrDefault(),
                horarioDetalle.HorarioDetalleEventos.Where(x => x.TipoEvento == HorarioDetalleEventoTipoEnum.Salida).FirstOrDefault()
            );
            return new JornalParams
            {
                FechaEntrada = fechaErr.AddDays(jornal.Item1.DiferenciaDia).ToDateTime(jornal.Item1.Hora),
                FechaSalida = fechaErr.AddDays(jornal.Item2.DiferenciaDia).ToDateTime(jornal.Item2.Hora),
                FechaEntradaConRango = fechaErr.AddDays(jornal.Item1.DiferenciaDia).ToDateTime(jornal.Item1.Hora).AddMinutes(jornal.Item1.VentanaMin),
                FechaSalidaConRango = fechaErr.AddDays(jornal.Item2.DiferenciaDia).ToDateTime(jornal.Item2.Hora).AddMinutes(jornal.Item1.VentanaMax),
                Evento = jornal.Item1
            };
        }

        public bool FechaEnRango(DateTime FechaRef, DateTime RangeMin, DateTime RangeMax)
        {
            return RangeMin <= FechaRef && FechaRef <= RangeMax;
        }

        public bool FechaEnRango(DateTime FechaRef, DateTime FechaBase, int VentanaMin, int VentanaMax)
        {
            return FechaEnRango(FechaRef, FechaBase.AddMinutes(-Math.Abs(VentanaMin)), FechaBase.AddMinutes(Math.Abs(VentanaMax)));
        }

        public class JornalParams
        {
            public DateTime FechaEntrada { get; set; }
            public DateTime FechaSalida { get; set; }
            public DateTime FechaEntradaConRango { get; set; }
            public DateTime FechaSalidaConRango { get; set; }
            public HorarioDetalleEvento Evento { get; set; }
        }
    }
}
