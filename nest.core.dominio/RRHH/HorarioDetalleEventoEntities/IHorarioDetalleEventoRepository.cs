namespace nest.core.dominio.RRHH.HorarioDetalleEventoEntities
{
    public interface IHorarioDetalleEventoRepository
    {
        Task<HorarioDetalleEvento> ObtenerPorId(long id);
        Task<List<HorarioDetalleEvento>> ObtenerPorIds(List<long> ids);
        Task<List<HorarioDetalleEvento>> ObtenerTodos();
        Task<HorarioDetalleEvento> Agregar(HorarioDetalleEvento entidad);
        Task<HorarioDetalleEvento[]> AgregarRange(HorarioDetalleEvento[] entidad);
        Task<HorarioDetalleEvento> Modificar(HorarioDetalleEvento entidad);
        Task<HorarioDetalleEvento[]> ModificarRange(HorarioDetalleEvento[] entidad);
        Task<HorarioDetalleEvento[]> FusionarRange(HorarioDetalleEvento[] originalEntities, HorarioDetalleEvento[] entidad);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
    }
}
