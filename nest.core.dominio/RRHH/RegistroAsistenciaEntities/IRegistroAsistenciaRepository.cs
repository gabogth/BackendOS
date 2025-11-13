using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.dominio.RRHH.RegistroAsistenciaEntities
{
    public interface IRegistroAsistenciaRepository
    {
        Task<RegistroAsistencia> ObtenerPorId(long id);
        Task<List<RegistroAsistencia>> ObtenerTodos();
        Task<List<RegistroAsistencia>> BuscarPorRangoFecha(int personalId, DateTime fechaInicio, DateTime fechaFin);
        Task<RegistroAsistencia> BuscarPorRangoFecha(int personalId, DateTime fechaInicio, DateTime fechaFin, HorarioDetalleEventoTipoEnum tipoMarca);
        Task<List<RegistroAsistenciaQueryView>> BuscarPorRangoFecha(DateTime fechaInicio, DateTime fechaFin);
        Task<List<RegistroAsistencia>> ObtenerPorIdUsuarioYRangoFecha(string UsuarioId, DateTime fechaInicio, DateTime fechaFin);
        Task<List<Personal>> BuscarPersonalAsistenciasRangoFechas(DateTime fechaInicio, DateTime fechaFin);
        Task<RegistroAsistencia> BuscarUltimaMarca(int personalId);
        Task<RegistroAsistencia> Agregar(RegistroAsistencia entidad);
        Task<RegistroAsistencia> Modificar(RegistroAsistencia entidad);
        Task Eliminar(long id);
    }
}
