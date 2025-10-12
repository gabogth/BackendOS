using System.Collections.Generic;
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

        public Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorIds(List<long> ids) => repository.ObtenerPorIds(ids);

        public Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorDetalle(long ordenTrabajoDetalleId) => repository.ObtenerPorDetalle(ordenTrabajoDetalleId);

        public Task<OrdenTrabajoDetalleActivo> Agregar(OrdenTrabajoDetalleActivoCrearDto entry) => repository.Agregar(entry);

        public Task<OrdenTrabajoDetalleActivo[]> AgregarRange(OrdenTrabajoDetalleActivoCrearDto[] entries) => repository.AgregarRange(entries);

        public Task<OrdenTrabajoDetalleActivo> Modificar(long id, OrdenTrabajoDetalleActivoCrearDto entry) => repository.Modificar(id, entry);

        public Task<OrdenTrabajoDetalleActivo[]> ModificarRange((long id, OrdenTrabajoDetalleActivoCrearDto entry)[] entries) => repository.ModificarRange(entries);

        public Task Eliminar(long id) => repository.Eliminar(id);

        public Task EliminarRange(long[] ids) => repository.EliminarRange(ids);

        public Task<OrdenTrabajoDetalleActivo[]> FusionarRange(OrdenTrabajoDetalleActivo[] originalEntities, (long id, OrdenTrabajoDetalleActivoCrearDto entry)[] entries) => repository.FusionarRange(originalEntities, entries);
    }
}
