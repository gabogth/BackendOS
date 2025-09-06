using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

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
        public Task<FinancieroCabecera> Agregar(FinancieroDto entry, bool transaccional) => repository.Agregar(entry, transaccional);
        public Task<FinancieroDetalle> AgregarDetalle(long financieroCabeceraId, FinancieroDetalleCrearDto entry) => repository.AgregarDetalle(financieroCabeceraId, entry);
        public Task<FinancieroCabecera> Modificar(long id, FinancieroDto entry, bool transaccional) => repository.Modificar(id, entry, transaccional);
        public Task<FinancieroDetalle> ModificarDetalle(long id, FinancieroDetalleCrearDto entry) => repository.ModificarDetalle(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
        public Task EliminarDetalle(long id) => repository.EliminarDetalle(id);
    }
}
