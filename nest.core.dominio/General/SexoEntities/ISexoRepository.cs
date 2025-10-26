namespace nest.core.dominio.General.SexoEntities
{
    public interface ISexoRepository
    {
        Task<Sexo> ObtenerPorId(byte id);
        Task<List<Sexo>> ObtenerTodos();
        Task<List<Sexo>> ObtenerActivos();
        Task<Sexo> Agregar(Sexo entry);
        Task<Sexo> Modificar(Sexo entry);
        Task Eliminar(byte id);
    }
}
