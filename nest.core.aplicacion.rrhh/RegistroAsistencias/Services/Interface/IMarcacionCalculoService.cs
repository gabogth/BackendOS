using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Services.Interface
{
    public interface IMarcacionCalculoService
    {
        Task<RegistroAsistencia> PrepararRegistroAsync(RegistroAsistencia registro, HorarioCabecera horario);
    }
}
