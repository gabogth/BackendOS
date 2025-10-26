namespace nest.core.dominio.Mantto.LaborEntities
{
    public interface ILaborRepository
    {
        Task<Labor> ObtenerPorId(int id);
        Task<List<Labor>> ObtenerTodos();
        Task<List<Labor>> ObtenerActivos();
        Task<Labor> Agregar(Labor entry);
        Task<Labor> Modificar(Labor entry);
        Task Eliminar(int id);
    }
}
