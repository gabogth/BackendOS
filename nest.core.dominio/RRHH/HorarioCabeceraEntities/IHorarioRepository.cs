namespace nest.core.dominio.RRHH.HorarioCabeceraEntities
{
    public interface IHorarioRepository
    {
        Task<HorarioCabecera> ObtenerPorId(int id);
        Task<List<HorarioCabecera>> ObtenerTodos();
        Task<HorarioCabecera> Agregar(HorarioCabecera entidad);
        Task<HorarioCabecera> Modificar(HorarioCabecera entidad);
        Task Eliminar(int id);
        Task<HorarioCabecera> ObtenerPorPersonalId(int personalId);
    }
}
