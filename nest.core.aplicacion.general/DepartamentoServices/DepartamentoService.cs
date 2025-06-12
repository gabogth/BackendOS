using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.DepartamentoServices
{
    public class DepartamentoService
    {
        private readonly IDepartamentoRepository repository;
        public DepartamentoService(IDepartamentoRepository repository)
        {
            this.repository = repository;
        }
        public Task<Departamento> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Departamento>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<Departamento> Agregar(DepartamentoCrearDto entry) => repository.Agregar(entry);
        public Task<Departamento> Modificar(int id, DepartamentoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
