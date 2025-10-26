namespace nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities
{
    public interface IOrdenTrabajoCabeceraRepository
    {
        Task<OrdenTrabajoCabecera> ObtenerPorId(long id);
        Task<List<OrdenTrabajoCabecera>> ObtenerTodos();
        Task<List<OrdenTrabajoCabecera>> ObtenerPorOrdenServicio(long ordenServicioCabeceraId);
        Task<OrdenTrabajoCabecera> ObtenerPorPersonaFechaInicialFechaFinal(int personaId, DateTime fecha);
        Task<OrdenTrabajoCabecera> Agregar(OrdenTrabajoCabecera dto);
        Task<OrdenTrabajoCabecera> Modificar(OrdenTrabajoCabecera dto);
        Task Eliminar(long id);
    }
}
