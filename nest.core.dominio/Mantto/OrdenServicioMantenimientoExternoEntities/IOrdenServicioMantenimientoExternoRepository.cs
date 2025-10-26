namespace nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities
{
    public interface IOrdenServicioMantenimientoExternoRepository
    {
        Task<OrdenServicioMantenimientoExterno> ObtenerPorId(long id);
        Task<List<OrdenServicioMantenimientoExterno>> ObtenerTodos();
        Task<OrdenServicioMantenimientoExterno> Agregar(OrdenServicioMantenimientoExterno entry);
        Task<OrdenServicioMantenimientoExterno> Modificar(OrdenServicioMantenimientoExterno entry);
        Task Eliminar(long id);
    }
}
