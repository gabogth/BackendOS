namespace nest.core.dominio.General.SexoEntities
{
    public interface ISexoRepository
    {
        Task<Sexo> ObtenerPorId(byte id);
        Task<List<Sexo>> ObtenerTodos();
        Task<List<Sexo>> ObtenerActivos();
        Task<Sexo> Agregar(SexoCrearDto entry);
        Task<Sexo> Modificar(byte id, SexoCrearDto entry);
        Task Eliminar(byte id);
    }
}
