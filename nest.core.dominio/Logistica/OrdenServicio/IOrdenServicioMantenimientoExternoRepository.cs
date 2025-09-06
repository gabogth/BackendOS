namespace nest.core.dominio.Logistica.OrdenServicio
{
    public interface IOrdenServicioMantenimientoExternoRepository
    {
        Task<OrdenServicioCabecera> ObtenerPorId(int id);
        Task<List<OrdenServicioCabecera>> ObtenerTodos();
        Task<OrdenServicioMantenimientoExterno> Agregar(OrdenServicioMantenimientoExternoCrearDto entry);
        Task<OrdenServicioCabecera> Modificar(int id, OrdenServicioMantenimientoExternoCrearDto entry);
        Task Eliminar(int id);
    }
}
