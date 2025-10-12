namespace nest.core.dominio.RRHH.HorarioDetalleEventoEntities
{
    public interface IHorarioDetalleEventoRepository
    {
        Task<HorarioDetalleEvento?> ObtenerPorId(long id);
        Task<List<HorarioDetalleEvento>> ObtenerPorHorarioDetalleId(long horarioDetalleId);
        Task<List<HorarioDetalleEvento>> ObtenerTodos();
        Task<HorarioDetalleEvento> Agregar(long horarioDetalleId, HorarioDetalleEventoCrearDto entidad);
        Task<HorarioDetalleEvento> Modificar(long id, HorarioDetalleEventoCrearDto entidad);
        Task Eliminar(long id);
    }
}
