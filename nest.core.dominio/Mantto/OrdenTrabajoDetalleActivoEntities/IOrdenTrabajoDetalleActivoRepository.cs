using System.Collections.Generic;

namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities
{
    public interface IOrdenTrabajoDetalleActivoRepository
    {
        Task<OrdenTrabajoDetalleActivo> ObtenerPorId(long id);
        Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorIds(List<long> ids);
        Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorDetalle(long ordenTrabajoDetalleId);
        Task<OrdenTrabajoDetalleActivo> Agregar(OrdenTrabajoDetalleActivoCrearDto dto);
        Task<OrdenTrabajoDetalleActivo[]> AgregarRange(OrdenTrabajoDetalleActivoCrearDto[] dto);
        Task<OrdenTrabajoDetalleActivo> Modificar(long id, OrdenTrabajoDetalleActivoCrearDto dto);
        Task<OrdenTrabajoDetalleActivo[]> ModificarRange((long id, OrdenTrabajoDetalleActivoCrearDto dto)[] dto);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<OrdenTrabajoDetalleActivo[]> FusionarRange(OrdenTrabajoDetalleActivo[] originalEntities, (long id, OrdenTrabajoDetalleActivoCrearDto dto)[] dto);
    }
}
