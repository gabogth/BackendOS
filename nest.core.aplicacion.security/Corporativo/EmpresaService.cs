using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.security.Corporativo
{
    public class EmpresaService
    {
        private IEmpresaRepository repository;
        public EmpresaService(IEmpresaRepository repository)
        {
            this.repository = repository;
        }

        public List<Empresa> ObtenerTodos() => this.repository.ObtenerTodos();
        public List<Empresa> ObtenerActivos() => this.repository.ObtenerActivos();
        public Empresa ObtenerPorId(byte id) => this.repository.ObtenerPorId(id);
    }
}
