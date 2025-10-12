namespace nest.core.dominio.RRHH.HorarioDetalleEventoEntities
{
    public interface IHorarioDetalleEventoRepository
    {
        Task<HorarioDetalleEvento> ObtenerPorId(long id);
        Task<List<HorarioDetalleEvento>> ObtenerPorIds(List<long> ids);
        Task<List<HorarioDetalleEvento>> ObtenerTodos();
        Task<HorarioDetalleEvento> Agregar(HorarioDetalleEventoCrearDto entidad);
        Task<HorarioDetalleEvento[]> AgregarRange(HorarioDetalleEventoCrearDto[] entidad);
        Task<HorarioDetalleEvento> Modificar(long id, HorarioDetalleEventoCrearDto entidad);
        Task<HorarioDetalleEvento[]> ModificarRange((long id, HorarioDetalleEventoCrearDto entidad)[] entidad);
        Task<HorarioDetalleEvento[]> FusionarRange(HorarioDetalleEvento[] originalEntities, (long id, HorarioDetalleEventoCrearDto entidad)[] entidad);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
    }
}
