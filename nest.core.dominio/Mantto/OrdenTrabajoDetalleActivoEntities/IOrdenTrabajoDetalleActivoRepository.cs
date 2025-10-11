namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities
{
    public interface IOrdenTrabajoDetalleActivoRepository
    {
        Task<OrdenTrabajoDetalleActivo> ObtenerPorId(long id);
        Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorDetalle(long ordenTrabajoDetalleId);
        Task<OrdenTrabajoDetalleActivo> Agregar(OrdenTrabajoDetalleActivoCrearDto dto);
        Task<OrdenTrabajoDetalleActivo> Modificar(long id, OrdenTrabajoDetalleActivoCrearDto dto);
        Task Eliminar(long id);
    }
}
