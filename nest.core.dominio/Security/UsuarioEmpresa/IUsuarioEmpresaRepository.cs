using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.dominio.Security.UsuarioEmpresa
{
    public interface IUsuarioEmpresaRepository
    {
        Task<UsuarioEmpresa> ObtenerPorId(long id);
        Task<List<UsuarioEmpresa>> ObtenerTodos();
        Task<List<UsuarioEmpresa>> GetAllByUsuarioIdAsync(string UsuarioId);
        Task<UsuarioEmpresa> Agregar(UsuarioEmpresaCrearDto entry);
        Task<UsuarioEmpresa> Modificar(long id, UsuarioEmpresaCrearDto entry);
        Task Eliminar(long id);
        Task Seleccionar(int EmpresaId, string UsuarioId);
    }
}
