namespace nest.core.dominio.Finanzas.FinancieroCabeceraEntities
{
    public interface IFinancieroCabeceraRepository
    {
        Task<FinancieroCabecera> ObtenerPorId(long id);
        Task<List<FinancieroCabecera>> ObtenerTodos();
        Task<FinancieroCabecera> Agregar(FinancieroCabecera entidad);
        Task<FinancieroCabecera> Modificar(FinancieroCabecera entidad);
        Task Eliminar(long id);
    }
}
