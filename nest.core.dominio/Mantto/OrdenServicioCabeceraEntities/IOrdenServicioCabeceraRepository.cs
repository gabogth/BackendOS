namespace nest.core.dominio.Mantto.OrdenServicioCabeceraEntities
{
    public interface IOrdenServicioCabeceraRepository
    {
        Task<OrdenServicioCabecera> ObtenerPorId(long id);
        Task<List<OrdenServicioCabecera>> ObtenerTodos();
        Task<OrdenServicioCabecera> Agregar(OrdenServicioCabeceraCrearDto dto);
        Task<OrdenServicioCabecera> Modificar(long id, OrdenServicioCabeceraCrearDto dto);
        Task Eliminar(long id);
    }
}
