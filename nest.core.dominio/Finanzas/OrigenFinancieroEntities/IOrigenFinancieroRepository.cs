namespace nest.core.dominio.Finanzas.OrigenFinancieroEntities
{
    public interface IOrigenFinancieroRepository
    {
        Task<OrigenFinanciero> ObtenerPorId(short id);
        Task<List<OrigenFinanciero>> ObtenerTodos();
        Task<List<OrigenFinanciero>> ObtenerActivos();
        Task<OrigenFinanciero> Agregar(OrigenFinanciero entidad);
        Task<OrigenFinanciero> Modificar(OrigenFinanciero entidad);
        Task Eliminar(short id);
    }
}
