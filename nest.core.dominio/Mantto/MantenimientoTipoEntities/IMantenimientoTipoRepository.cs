namespace nest.core.dominio.Mantto.MantenimientoTipoEntities
{
    public interface IMantenimientoTipoRepository
    {
        Task<MantenimientoTipo> ObtenerPorId(short id);
        Task<List<MantenimientoTipo>> ObtenerTodos();
        Task<List<MantenimientoTipo>> ObtenerActivos();
        Task<MantenimientoTipo> Agregar(MantenimientoTipo entry);
        Task<MantenimientoTipo> Modificar(MantenimientoTipo entry);
        Task Eliminar(short id);
    }
}
