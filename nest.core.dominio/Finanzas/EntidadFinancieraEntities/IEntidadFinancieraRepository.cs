namespace nest.core.dominio.Finanzas.EntidadFinancieraEntities
{
    public interface IEntidadFinancieraRepository
    {
        Task<EntidadFinanciera> ObtenerPorId(int id);
        Task<List<EntidadFinanciera>> ObtenerTodos();
        Task<List<EntidadFinanciera>> ObtenerActivos();
        Task<EntidadFinanciera> Agregar(EntidadFinanciera entry);
        Task<EntidadFinanciera> Modificar(EntidadFinanciera entry);
        Task Eliminar(int id);
    }
}
