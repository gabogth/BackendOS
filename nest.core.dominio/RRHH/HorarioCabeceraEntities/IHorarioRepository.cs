namespace nest.core.dominio.RRHH.HorarioCabeceraEntities
{
    public interface IHorarioRepository
    {
        Task<HorarioCabecera> ObtenerPorId(int id);
        Task<List<HorarioCabecera>> ObtenerTodos();
        Task<HorarioCabecera> Agregar(HorarioDto entidad);
        Task<HorarioCabecera> Modificar(int id, HorarioDto entidad);
        Task Eliminar(int id);
    }
}
