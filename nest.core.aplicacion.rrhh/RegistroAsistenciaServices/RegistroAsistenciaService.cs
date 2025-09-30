using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaServices
{
    public class RegistroAsistenciaService
    {
        private readonly IRegistroAsistenciaRepository repository;
        private readonly IHorarioRepository horarioRepository;
        private readonly IPersonalRepository personalRepository;

        public RegistroAsistenciaService(IRegistroAsistenciaRepository repository, IHorarioRepository horarioRepository, IPersonalRepository personalRepository)
        {
            this.repository = repository;
            this.horarioRepository = horarioRepository;
            this.personalRepository = personalRepository;
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
        }

        //public (DateTime, HorarioDetalle)? GetHorarioPorFecha(HorarioCabecera horario, DateTime fechaRegistro)
        //{
        //    List<(DateTime, HorarioDetalle)> values = new List<(DateTime, HorarioDetalle)>();

        //    HorarioDetalle? ayer = horario.HorarioDetalles.Where(x => x.DiaSemana == DayOfWeekUtils.Ayer(fechaRegistro.DayOfWeek)).FirstOrDefault();
        //    HorarioDetalle? hoy = horario.HorarioDetalles.Where(x => x.DiaSemana == fechaRegistro.DayOfWeek).FirstOrDefault();
        //    HorarioDetalle? manana = horario.HorarioDetalles.Where(x => x.DiaSemana == DayOfWeekUtils.Manana(fechaRegistro.DayOfWeek)).FirstOrDefault();

        //    if (ayer == null || hoy == null || manana == null)
        //        return null;

        //    DateOnly fechaAyerErr = DateOnly.FromDateTime(fechaRegistro.AddDays(-1));
        //    DateOnly fechaHoyErr = DateOnly.FromDateTime(fechaRegistro);
        //    DateOnly fechaMananaErr = DateOnly.FromDateTime(fechaRegistro.AddDays(1));

        //    DateTime fechaAyer = fechaAyerErr.ToDateTime(ayer.GrupoHorario.HoraEntrada);
        //    DateTime fechaHoy = fechaHoyErr.ToDateTime(hoy.GrupoHorario.HoraEntrada);
        //    DateTime fechaManana = fechaAyerErr.ToDateTime(manana.GrupoHorario.HoraEntrada);

        //    values.Add((fechaAyer, ayer));
        //    values.Add((fechaHoy, hoy));
        //    values.Add((fechaManana, manana));

        //    (DateTime, HorarioDetalle)? horarioActual = values.Where(d =>
        //            FechaEnRango(fechaRegistro, d.Item1, d.Item2.GrupoHorario.VentanaEntradaMin, d.Item2.GrupoHorario.VentanaEntradaMax)
        //        ).FirstOrDefault();
        //    if (!horarioActual.HasValue)
        //        return null;

        //    return horarioActual.Value;
        //}

        //public bool FechaEnRango(DateTime FechaRef, DateTime RangeMin, DateTime RangeMax)
        //{
        //    return RangeMin <= FechaRef && FechaRef <= RangeMax;
        //}

        //public bool FechaEnRango(DateTime FechaRef, DateTime FechaBase, int VentanaMin, int VentanaMax)
        //{
        //    return FechaEnRango(FechaRef, FechaBase.AddMinutes(-Math.Abs(VentanaMin)), FechaBase.AddMinutes(Math.Abs(VentanaMax)));
        //}
    }
}
