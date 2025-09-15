using nest.core.dominio.Security.UsuarioEmpresa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.aplicacion.security.UsuarioEmpresaServices
{
    public class UsuarioEmpresaService
    {
        private readonly IUsuarioEmpresaRepository repository;
        public UsuarioEmpresaService(IUsuarioEmpresaRepository repository)
        {
            this.repository = repository;
        }
        public Task<UsuarioEmpresa> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<UsuarioEmpresa>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<UsuarioEmpresa>> ObtenerByUsuarioIdAsync(string UsuarioId) => repository.GetAllByUsuarioIdAsync(UsuarioId);
        public Task<UsuarioEmpresa> Agregar(UsuarioEmpresaCrearDto entry) => repository.Agregar(entry);
        public Task<UsuarioEmpresa> Modificar(long id, UsuarioEmpresaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
        public Task Seleccionar(UsuarioEmpresaSeleccionarDto entry) => repository.Seleccionar(entry.EmpresaId, entry.UsuarioId);
    }
}
