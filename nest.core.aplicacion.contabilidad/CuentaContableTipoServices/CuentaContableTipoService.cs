using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipoServices
{
    public class CuentaContableTipoService
    {
        private readonly ICuentaContableTipoRepository repository;
        public CuentaContableTipoService(ICuentaContableTipoRepository repository)
        {
            this.repository = repository;
        }
        public Task<CuentaContableTipo> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<CuentaContableTipo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<CuentaContableTipo>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<CuentaContableTipo> Agregar(CuentaContableTipoCrearDto entry) => repository.Agregar(entry);
        public Task<CuentaContableTipo> Modificar(int id, CuentaContableTipoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
