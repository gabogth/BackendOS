using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.Aplicacion.Formulario
{
    public interface IFormularioRepository
    {
        Task<Formulario> ObtenerPorId(int id);
        Task<List<Formulario>> ObtenerPorModuloId(int moduloId);
        Task<List<Formulario>> ObtenerTodos();
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<List<Formulario>> ObtenerPorUnaPropiedad(Dictionary<string, object?> filtros);
        Task<List<Formulario>> ObtenerPorRolId(string roleId);
        Task<List<Formulario>> ObtenerPorUserId(string userId);
        Task<Formulario> Agregar(Formulario entry);
        Task<Formulario> Modificar(Formulario entry);
        Task Eliminar(int id);
    }
}
