namespace nest.core.dominio.RRHH.GrupoHorarioEntities
{
    public interface IGrupoHorarioRepository
    {
        Task<GrupoHorario> ObtenerPorId(int id);
        Task<List<GrupoHorario>> ObtenerTodos();
        Task<List<GrupoHorario>> ObtenerActivos();
        Task<GrupoHorario> Agregar(GrupoHorarioCrearDto entidad);
        Task<GrupoHorario> Modificar(int id, GrupoHorarioCrearDto entidad);
        Task Eliminar(int id);
    }
}
