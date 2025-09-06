namespace nest.core.dominio.Mantto.MantenimientoTipoEntities
{
    public interface IMantenimientoTipoRepository
    {
        Task<MantenimientoTipo> ObtenerPorId(short id);
        Task<List<MantenimientoTipo>> ObtenerTodos();
        Task<List<MantenimientoTipo>> ObtenerActivos();
        Task<MantenimientoTipo> Agregar(MantenimientoTipoCrearDto entry);
        Task<MantenimientoTipo> Modificar(short id, MantenimientoTipoCrearDto entry);
        Task Eliminar(short id);
    }
}
