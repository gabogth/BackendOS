using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Aplicacion
{
    public class FormularioService
    {
        private readonly IFormularioRepository repository;
        public FormularioService(IFormularioRepository repository)
        {
            this.repository = repository;
        }

        public Task<Formulario> ObtenerPorId(int id) => this.repository.ObtenerPorId(id);
        public Task<List<Formulario>> ObtenerPorModuloId(int moduloId) => this.repository.ObtenerPorModuloId(moduloId);
        public Task<List<Formulario>> ObtenerTodos() => this.repository.ObtenerTodos();
        public Task<List<Formulario>> ObtenerPorUnaPropiedad(Dictionary<string, object> filtros) => this.repository.ObtenerPorUnaPropiedad(filtros);
        public Task<List<Formulario>> ObtenerPorRolId(string roleId) => this.repository.ObtenerPorRolId(roleId);
        public Task<Formulario> Agregar(FormularioCrearDto entry) => this.repository.Agregar(entry);
        public Task<Formulario> Modificar(int id, FormularioCrearDto entry) => this.repository.Modificar(id, entry);
        public Task Eliminar(int id) => this.repository.Eliminar(id);

    }
}
