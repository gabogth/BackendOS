using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.FinancieroServices
{
    public class FinancieroService
    {
        private readonly IFinancieroRepository repository;
        public FinancieroService(IFinancieroRepository repository)
        {
            this.repository = repository;
        }
        public Task<FinancieroCabecera> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<FinancieroCabecera>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<FinancieroCabecera> Agregar(FinancieroDto entry) => repository.Agregar(entry);
        public Task<FinancieroCabecera> Modificar(long id, FinancieroDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
