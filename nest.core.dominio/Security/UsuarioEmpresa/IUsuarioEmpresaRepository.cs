using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.dominio.Security.UsuarioEmpresa
{
    public interface IUsuarioEmpresaRepository
    {
        Task<UsuarioEmpresa?> ObtenerPorId(long id);
        Task<List<UsuarioEmpresa>> ObtenerTodos();
        Task<List<UsuarioEmpresa>> GetAllByUsuarioIdAsync(string usuarioId);
        Task<UsuarioEmpresa> Agregar(UsuarioEmpresa entry);
        Task<UsuarioEmpresa> Modificar(UsuarioEmpresa entry);
        Task Eliminar(long id);
        Task Seleccionar(string usuarioId, int empresaId);
        Task<UsuarioEmpresa?> ObtenerSeleccionado(string usuarioId);
    }
}
