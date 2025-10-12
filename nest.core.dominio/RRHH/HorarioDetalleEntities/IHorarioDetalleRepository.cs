namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public interface IHorarioDetalleRepository
    {
        Task<HorarioDetalle> ObtenerPorId(long id);
        Task<List<HorarioDetalle>> ObtenerPorIds(List<long> ids);
        Task<List<HorarioDetalle>> ObtenerTodos();
        Task<HorarioDetalle> Agregar(HorarioDetalleCrearDto entidad);
        Task<HorarioDetalle[]> AgregarRange(HorarioDetalleCrearDto[] entidad);
        Task<HorarioDetalle> Modificar(long id, HorarioDetalleCrearDto entidad);
        Task<HorarioDetalle[]> ModificarRange((long id, HorarioDetalleCrearDto entidad)[] entidad);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<HorarioDetalle[]> FusionarRange(HorarioDetalle[] originalEntities, (long id, HorarioDetalleCrearDto entidad)[] entidad);
    }
}
