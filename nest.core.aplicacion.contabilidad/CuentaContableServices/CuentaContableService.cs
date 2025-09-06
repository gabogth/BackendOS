using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContableServices
{
    public class CuentaContableService
    {
        private readonly ICuentaContableRepository repository;
        public CuentaContableService(ICuentaContableRepository repository)
        {
            this.repository = repository;
        }
        public Task<CuentaContable> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<CuentaContable>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<CuentaContable>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<CuentaContable> Agregar(CuentaContableCrearDto entry) => repository.Agregar(entry);
        public Task<CuentaContable> Modificar(int id, CuentaContableCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
