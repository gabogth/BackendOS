namespace nest.core.dominio.Mantto.OrdenServicioTipoEntities
{
    public interface IOrdenServicioTipoRepository
    {
        Task<OrdenServicioTipo> ObtenerPorId(short id);
        Task<List<OrdenServicioTipo>> ObtenerTodos();
        Task<List<OrdenServicioTipo>> ObtenerActivos();
        Task<OrdenServicioTipo> Agregar(OrdenServicioTipo entry);
        Task<OrdenServicioTipo> Modificar(OrdenServicioTipo entry);
        Task Eliminar(short id);
    }
}
