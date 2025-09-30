namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public interface IHorarioDetalleRepository
    {
        Task<HorarioDetalle?> ObtenerPorId(long id);
        Task<List<HorarioDetalle>> ObtenerPorCabeceraId(int horarioCabeceraId);
        Task<List<HorarioDetalle>> ObtenerTodos();
        Task<HorarioDetalle> Agregar(int horarioCabeceraId, HorarioDetalleCrearDto entidad);
        Task<HorarioDetalle> Modificar(long id, HorarioDetalleCrearDto entidad);
        Task Eliminar(long id);
    }
}
