using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.RRHH.PersonalEntities
{
    public interface IPersonalRepository
    {
        Task<Personal> ObtenerPorId(int id);
        Task<List<Personal>> ObtenerTodos();
        Task<List<Personal>> ObtenerActivos();
        Task<Personal> ObtenerPorDocumentoIdentidad(int tipoDocumentoId, string documentoIdentidad);
        Task<Personal> ObtenerPorIdUsuario(string idUsuario);
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<Personal> Agregar(Personal entry);
        Task<Personal> Modificar(Personal entry);
        Task Eliminar(int id);
    }
}
