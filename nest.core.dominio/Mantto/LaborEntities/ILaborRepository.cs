namespace nest.core.dominio.Mantto.LaborEntities
{
    public interface ILaborRepository
    {
        Task<Labor> ObtenerPorId(int id);
        Task<List<Labor>> ObtenerTodos();
        Task<List<Labor>> ObtenerActivos();
        Task<Labor> Agregar(LaborCrearDto entry);
        Task<Labor> Modificar(int id, LaborCrearDto entry);
        Task Eliminar(int id);
    }
}
