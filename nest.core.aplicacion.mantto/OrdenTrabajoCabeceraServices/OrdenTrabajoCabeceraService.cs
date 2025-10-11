using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceraServices
{
    public class OrdenTrabajoCabeceraService
    {
        private readonly IOrdenTrabajoCabeceraRepository repository;

        public OrdenTrabajoCabeceraService(IOrdenTrabajoCabeceraRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenTrabajoCabecera> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenTrabajoCabecera>> ObtenerTodos() => repository.ObtenerTodos();

        public Task<List<OrdenTrabajoCabecera>> ObtenerPorOrdenServicio(long ordenServicioCabeceraId) => repository.ObtenerPorOrdenServicio(ordenServicioCabeceraId);

        public Task<OrdenTrabajoCabecera> Agregar(OrdenTrabajoCabeceraCrearDto entry) => repository.Agregar(entry);

        public Task<OrdenTrabajoCabecera> Modificar(long id, OrdenTrabajoCabeceraCrearDto entry) => repository.Modificar(id, entry);

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
