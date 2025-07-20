using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.aplicacion.finanzas.OrigenFinancieroServices
{
    public class OrigenFinancieroService
    {
        private readonly IOrigenFinancieroRepository repository;
        public OrigenFinancieroService(IOrigenFinancieroRepository repository)
        {
            this.repository = repository;
        }
        public Task<OrigenFinanciero> ObtenerPorId(short id) => repository.ObtenerPorId(id);
        public Task<List<OrigenFinanciero>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<OrigenFinanciero>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<OrigenFinanciero> Agregar(OrigenFinancieroCrearDto entry) => repository.Agregar(entry);
        public Task<OrigenFinanciero> Modificar(short id, OrigenFinancieroCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(short id) => repository.Eliminar(id);
    }
}
