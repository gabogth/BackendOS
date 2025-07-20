using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.aplicacion.finanzas.CuentaCorrienteServices
{
    public class CuentaCorrienteService
    {
        private readonly ICuentaCorrienteRepository repository;
        public CuentaCorrienteService(ICuentaCorrienteRepository repository)
        {
            this.repository = repository;
        }
        public Task<CuentaCorriente> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<CuentaCorriente>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<CuentaCorriente>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<CuentaCorriente> Agregar(CuentaCorrienteCrearDto entry) => repository.Agregar(entry);
        public Task<CuentaCorriente> Modificar(int id, CuentaCorrienteCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
