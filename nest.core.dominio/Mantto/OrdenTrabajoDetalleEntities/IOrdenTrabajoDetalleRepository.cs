using System.Collections.Generic;

namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities
{
    public interface IOrdenTrabajoDetalleRepository
    {
        Task<OrdenTrabajoDetalle> ObtenerPorId(long id);
        Task<List<OrdenTrabajoDetalle>> ObtenerPorIds(List<long> ids);
        Task<List<OrdenTrabajoDetalle>> ObtenerPorCabecera(long ordenTrabajoCabeceraId);
        Task<OrdenTrabajoDetalle> Agregar(OrdenTrabajoDetalleCrearDto dto);
        Task<OrdenTrabajoDetalle[]> AgregarRange(OrdenTrabajoDetalleCrearDto[] dto);
        Task<OrdenTrabajoDetalle> Modificar(long id, OrdenTrabajoDetalleCrearDto dto);
        Task<OrdenTrabajoDetalle[]> ModificarRange((long id, OrdenTrabajoDetalleCrearDto dto)[] dto);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<OrdenTrabajoDetalle[]> FusionarRange(OrdenTrabajoDetalle[] originalEntities, (long id, OrdenTrabajoDetalleCrearDto dto)[] dto);
    }
}
