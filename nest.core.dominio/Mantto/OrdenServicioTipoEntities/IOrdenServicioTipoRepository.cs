namespace nest.core.dominio.Mantto.OrdenServicioTipoEntities
{
    public interface IOrdenServicioTipoRepository
    {
        Task<OrdenServicioTipo> ObtenerPorId(short id);
        Task<List<OrdenServicioTipo>> ObtenerTodos();
        Task<List<OrdenServicioTipo>> ObtenerActivos();
        Task<OrdenServicioTipo> Agregar(OrdenServicioTipoCrearDto entry);
        Task<OrdenServicioTipo> Modificar(short id, OrdenServicioTipoCrearDto entry);
        Task Eliminar(short id);
    }
}
