using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivoServices
{
    public class OrdenTrabajoDetalleActivoService
    {
        private readonly IOrdenTrabajoDetalleActivoRepository repository;

        public OrdenTrabajoDetalleActivoService(IOrdenTrabajoDetalleActivoRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenTrabajoDetalleActivo> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorDetalle(long ordenTrabajoDetalleId) => repository.ObtenerPorDetalle(ordenTrabajoDetalleId);

        public Task<OrdenTrabajoDetalleActivo> Agregar(OrdenTrabajoDetalleActivoCrearDto entry) => repository.Agregar(entry);

        public Task<OrdenTrabajoDetalleActivo> Modificar(long id, OrdenTrabajoDetalleActivoCrearDto entry) => repository.Modificar(id, entry);

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
