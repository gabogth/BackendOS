namespace nest.core.dominio.Patrimonial.ActivoEntities
{
    public interface IActivoRepository
    {
        Task<Activo> ObtenerPorId(long id);
        Task<List<Activo>> ObtenerTodos();
        Task<List<Activo>> ObtenerActivos();
        Task<Activo> Agregar(Activo entry);
        Task<Activo> Modificar(Activo entry);
        Task Eliminar(long id);
    }
}
