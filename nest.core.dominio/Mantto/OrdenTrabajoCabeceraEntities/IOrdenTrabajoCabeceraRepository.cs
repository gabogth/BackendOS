namespace nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities
{
    public interface IOrdenTrabajoCabeceraRepository
    {
        Task<OrdenTrabajoCabecera> ObtenerPorId(long id);
        Task<List<OrdenTrabajoCabecera>> ObtenerTodos();
        Task<List<OrdenTrabajoCabecera>> ObtenerPorOrdenServicio(long ordenServicioCabeceraId);
        Task<OrdenTrabajoCabecera> Agregar(OrdenTrabajoCabeceraCrearDto dto);
        Task<OrdenTrabajoCabecera> Modificar(long id, OrdenTrabajoCabeceraCrearDto dto);
        Task Eliminar(long id);
    }
}
