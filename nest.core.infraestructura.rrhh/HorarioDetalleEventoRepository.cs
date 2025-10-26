using AutoMapper;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh;

public class HorarioDetalleEventoRepository : CrudRepositoryBase<HorarioDetalleEvento, long>, IHorarioDetalleEventoRepository
{
    public HorarioDetalleEventoRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }
    public Task<HorarioDetalleEvento> ObtenerPorId(long id) => GetByIdAsync(id);
    public Task<List<HorarioDetalleEvento>> ObtenerPorIds(List<long> ids) => GetByIdsAsync(ids);
    public Task<List<HorarioDetalleEvento>> ObtenerTodos() => GetAllAsync();
    public async Task<HorarioDetalleEvento> Agregar(HorarioDetalleEvento entidad) => await AddAsync(entidad);
    public async Task<HorarioDetalleEvento[]> AgregarRange(HorarioDetalleEvento[] entidad)
    {
        HorarioDetalleEvento[] results = await AddRangeAsync(entidad);
        List<HorarioDetalleEvento> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
        return GetOrderedArrayFrom(completed, results);
    }
    public async Task<HorarioDetalleEvento> Modificar(HorarioDetalleEvento entidad)
    {
        var updated = await UpdateAsync(entidad);
        return await ObtenerPorId(updated.Id);
    }
    public async Task<HorarioDetalleEvento[]> ModificarRange(HorarioDetalleEvento[] entidad)
    {
        HorarioDetalleEvento[] results = await UpdateRangeAsync(entidad);
        List<HorarioDetalleEvento> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
        return GetOrderedArrayFrom(completed, results);
    }
    public async Task<HorarioDetalleEvento[]> FusionarRange(HorarioDetalleEvento[] originalEntities, HorarioDetalleEvento[] entidad)
    {
        HorarioDetalleEvento[] results = await MergeRangeAsync(originalEntities, entidad);
        List<HorarioDetalleEvento> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
        return GetOrderedArrayFrom(completed, results);
    }
    public Task Eliminar(long id) => DeleteAsync(id);
    public Task EliminarRange(long[] ids) => DeleteRangeAsync(ids);
}
