using System.Collections.Generic;
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

        public Task<List<OrdenTrabajoDetalle>> ObtenerPorIds(List<long> ids) => repository.ObtenerPorIds(ids);

        public Task<List<OrdenTrabajoDetalle>> ObtenerPorCabecera(long ordenTrabajoCabeceraId) => repository.ObtenerPorCabecera(ordenTrabajoCabeceraId);

        public Task<OrdenTrabajoDetalle> Agregar(OrdenTrabajoDetalleCrearDto entry) => repository.Agregar(entry);

        public Task<OrdenTrabajoDetalle[]> AgregarRange(OrdenTrabajoDetalleCrearDto[] entries) => repository.AgregarRange(entries);

        public Task<OrdenTrabajoDetalle> Modificar(long id, OrdenTrabajoDetalleCrearDto entry) => repository.Modificar(id, entry);

        public Task<OrdenTrabajoDetalle[]> ModificarRange((long id, OrdenTrabajoDetalleCrearDto entry)[] entries) => repository.ModificarRange(entries);

        public Task Eliminar(long id) => repository.Eliminar(id);

        public Task EliminarRange(long[] ids) => repository.EliminarRange(ids);

        public Task<OrdenTrabajoDetalle[]> FusionarRange(OrdenTrabajoDetalle[] originalEntities, (long id, OrdenTrabajoDetalleCrearDto entry)[] entries) => repository.FusionarRange(originalEntities, entries);
    }
}
