using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Services.Interface
{
    public interface IMarcacionCalculoService
    {
        Task<RegistroAsistencia> PrepararRegistroAsync(RegistroAsistencia registro, HorarioCabecera horario, DateOnly? fechaBase = null);
        Task<ResultadoCalculoOrdenTrabajo> PrepararRegistroOrdenTrabajoAsync(RegistroAsistencia registro);
    }

    public sealed record ResultadoCalculoOrdenTrabajo(
        RegistroAsistencia Registro,
        OrdenTrabajoHorario? OrdenTrabajoHorario);
}
