namespace nest.core.dominio.Finanzas.OrigenFinancieroEntities
{
    public interface IOrigenFinancieroRepository
    {
        Task<OrigenFinanciero> ObtenerPorId(short id);
        Task<List<OrigenFinanciero>> ObtenerTodos();
        Task<List<OrigenFinanciero>> ObtenerActivos();
        Task<OrigenFinanciero> Agregar(OrigenFinancieroCrearDto entidad);
        Task<OrigenFinanciero> Modificar(short id, OrigenFinancieroCrearDto entidad);
        Task Eliminar(short id);
    }
}
