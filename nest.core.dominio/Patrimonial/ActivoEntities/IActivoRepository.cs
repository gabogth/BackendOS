namespace nest.core.dominio.Patrimonial.ActivoEntities
{
    public interface IActivoRepository
    {
        Task<Activo> ObtenerPorId(long id);
        Task<List<Activo>> ObtenerTodos();
        Task<List<Activo>> ObtenerActivos();
        Task<Activo> Agregar(ActivoCrearDto entry);
        Task<Activo> Modificar(long id, ActivoCrearDto entry);
        Task Eliminar(long id);
    }
}
