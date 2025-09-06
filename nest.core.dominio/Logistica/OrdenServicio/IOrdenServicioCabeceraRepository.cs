namespace nest.core.dominio.Logistica.OrdenServicio
{
    public interface IOrdenServicioCabeceraRepository
    {
        Task<OrdenServicioCabecera> ObtenerPorId(int id);
        Task<List<OrdenServicioCabecera>> ObtenerTodos();
        Task<OrdenServicioCabecera> Agregar(OrdenServicioCabeceraCrearDto entry);
        Task<OrdenServicioCabecera> Modificar(int id, OrdenServicioCabeceraCrearDto entry);
        Task Eliminar(int id);
    }
}
