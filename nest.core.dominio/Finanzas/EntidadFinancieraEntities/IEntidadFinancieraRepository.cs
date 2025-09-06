namespace nest.core.dominio.Finanzas.EntidadFinancieraEntities
{
    public interface IEntidadFinancieraRepository
    {
        Task<EntidadFinanciera> ObtenerPorId(int id);
        Task<List<EntidadFinanciera>> ObtenerTodos();
        Task<List<EntidadFinanciera>> ObtenerActivos();
        Task<EntidadFinanciera> Agregar(EntidadFinancieraCrearDto entidad);
        Task<EntidadFinanciera> Modificar(int id, EntidadFinancieraCrearDto entidad);
        Task Eliminar(int id);
    }
}
