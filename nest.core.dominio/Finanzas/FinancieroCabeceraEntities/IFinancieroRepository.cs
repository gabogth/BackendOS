namespace nest.core.dominio.Finanzas.FinancieroCabeceraEntities
{
    public interface IFinancieroRepository
    {
        Task<FinancieroCabecera> ObtenerPorId(long id);
        Task<List<FinancieroCabecera>> ObtenerTodos();
        Task<FinancieroCabecera> Agregar(FinancieroDto entidad);
        Task<FinancieroCabecera> Modificar(long id, FinancieroDto entidad);
        Task Eliminar(long id);
    }
}
