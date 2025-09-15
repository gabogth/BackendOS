using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.EmpresaServices
{
    public class EmpresaService
    {
        private readonly IEmpresaRepository repository;

        public EmpresaService(IEmpresaRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Empresa>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Empresa>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Empresa?> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<Empresa> Agregar(EmpresaCrearDto entry) => repository.Agregar(entry);
        public Task<Empresa> Modificar(int id, EmpresaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}

