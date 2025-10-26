namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public interface IHorarioDetalleRepository
    {
        Task<HorarioDetalle> ObtenerPorId(long id);
        Task<List<HorarioDetalle>> ObtenerPorIds(List<long> ids);
        Task<List<HorarioDetalle>> ObtenerTodos();
        Task<HorarioDetalle> Agregar(HorarioDetalle entidad);
        Task<HorarioDetalle[]> AgregarRange(HorarioDetalle[] entidad);
        Task<HorarioDetalle> Modificar(HorarioDetalle entidad);
        Task<HorarioDetalle[]> ModificarRange(HorarioDetalle[] entidad);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<HorarioDetalle[]> FusionarRange(HorarioDetalle[] originalEntities, HorarioDetalle[] entidad);
    }
}
