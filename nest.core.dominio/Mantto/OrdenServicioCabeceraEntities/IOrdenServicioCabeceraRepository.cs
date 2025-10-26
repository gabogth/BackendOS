namespace nest.core.dominio.Mantto.OrdenServicioCabeceraEntities
{
    public interface IOrdenServicioCabeceraRepository
    {
        Task<OrdenServicioCabecera> ObtenerPorId(long id);
        Task<List<OrdenServicioCabecera>> ObtenerTodos();
        Task<OrdenServicioCabecera> Agregar(OrdenServicioCabecera entry);
        Task<OrdenServicioCabecera> Modificar(OrdenServicioCabecera entry);
        Task Eliminar(long id);
    }
}
