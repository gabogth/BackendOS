namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities
{
    public interface IOrdenTrabajoDetalleRepository
    {
        Task<OrdenTrabajoDetalle> ObtenerPorId(long id);
        Task<List<OrdenTrabajoDetalle>> ObtenerPorCabecera(long ordenTrabajoCabeceraId);
        Task<OrdenTrabajoDetalle> Agregar(OrdenTrabajoDetalleCrearDto dto);
        Task<OrdenTrabajoDetalle> Modificar(long id, OrdenTrabajoDetalleCrearDto dto);
        Task Eliminar(long id);
    }
}
