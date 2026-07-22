using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.RRHH.PersonalEstadoEntities
{
    public interface IPersonalEstadoRepository
    {
        Task<PersonalEstado> ObtenerPorId(byte id);
        Task<List<PersonalEstado>> ObtenerTodos();
        Task<List<PersonalEstado>> ObtenerActivos();
        Task<PersonalEstado> Agregar(PersonalEstado entidad);
        Task<PersonalEstado> Modificar(PersonalEstado entidad);
        Task Eliminar(byte id);
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
    }
}
