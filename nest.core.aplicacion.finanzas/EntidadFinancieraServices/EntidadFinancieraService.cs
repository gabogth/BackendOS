using nest.core.dominio.Finanzas.EntidadFinancieraEntities;

namespace nest.core.aplicacion.finanzas.EntidadFinancieraServices
{
    public class EntidadFinancieraService
    {
        private readonly IEntidadFinancieraRepository repository;
        public EntidadFinancieraService(IEntidadFinancieraRepository repository)
        {
            this.repository = repository;
        }
        public Task<EntidadFinanciera> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<EntidadFinanciera>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<EntidadFinanciera>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<EntidadFinanciera> Agregar(EntidadFinancieraCrearDto entry) => repository.Agregar(entry);
        public Task<EntidadFinanciera> Modificar(int id, EntidadFinancieraCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
