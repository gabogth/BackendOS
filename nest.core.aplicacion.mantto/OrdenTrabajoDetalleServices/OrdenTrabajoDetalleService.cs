using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleServices
{
    public class OrdenTrabajoDetalleService
    {
        private readonly IOrdenTrabajoDetalleRepository repository;

        public OrdenTrabajoDetalleService(IOrdenTrabajoDetalleRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenTrabajoDetalle> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenTrabajoDetalle>> ObtenerPorCabecera(long ordenTrabajoCabeceraId) => repository.ObtenerPorCabecera(ordenTrabajoCabeceraId);

        public Task<OrdenTrabajoDetalle> Agregar(OrdenTrabajoDetalleCrearDto entry) => repository.Agregar(entry);

        public Task<OrdenTrabajoDetalle> Modificar(long id, OrdenTrabajoDetalleCrearDto entry) => repository.Modificar(id, entry);

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
