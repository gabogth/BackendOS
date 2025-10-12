namespace nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities
{
    public interface IOrdenServicioMantenimientoExternoRepository
    {
        Task<OrdenServicioMantenimientoExterno> ObtenerPorId(long id);
        Task<List<OrdenServicioMantenimientoExterno>> ObtenerTodos();
        Task<OrdenServicioMantenimientoExterno> Agregar(OrdenServicioMantenimientoExternoCrearDto dto);
        Task<OrdenServicioMantenimientoExterno> Modificar(long id, OrdenServicioMantenimientoExternoCrearDto dto);
        Task Eliminar(long id);
    }
}
