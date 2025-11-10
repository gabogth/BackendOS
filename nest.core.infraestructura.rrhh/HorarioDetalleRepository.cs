using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh;

public class HorarioDetalleRepository : CrudRepositoryBase<HorarioDetalle, long>, IHorarioDetalleRepository
{
    public HorarioDetalleRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

    protected override IQueryable<HorarioDetalle> Query() => context.HorarioDetalles
        .AsNoTracking()
        .Include(x => x.HorarioDetalleEventos);
    public Task<HorarioDetalle> ObtenerPorId(long id) => GetByIdAsync(id);
    public Task<List<HorarioDetalle>> ObtenerPorIds(List<long> ids) => GetByIdsAsync(ids);
    public Task<List<HorarioDetalle>> ObtenerTodos() => GetAllAsync();
    public Task<HorarioDetalle> Agregar(HorarioDetalle entidad) => AddAsync(entidad);
    public async Task<HorarioDetalle[]> AgregarRange(HorarioDetalle[] entidad)
    {
        HorarioDetalle[] results = await AddRangeAsync(entidad);
        List<HorarioDetalle> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
        return GetOrderedArrayFrom(completed, results);
    }
    public async Task<HorarioDetalle> Modificar(HorarioDetalle entidad)
    {
        var updated = await UpdateAsync(entidad);
        return await ObtenerPorId(updated.Id);
    }
    public async Task<HorarioDetalle[]> ModificarRange(HorarioDetalle[] entidad)
    {
        HorarioDetalle[] results = await UpdateRangeAsync(entidad);
        List<HorarioDetalle> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
        return GetOrderedArrayFrom(completed, results);
    }
    public Task Eliminar(long id) => DeleteAsync(id);
    public Task EliminarRange(long[] ids) => DeleteRangeAsync(ids);
    public async Task<HorarioDetalle[]> FusionarRange(HorarioDetalle[] originalEntities, HorarioDetalle[] entidad)
    {
        HorarioDetalle hd1 = context.HorarioDetalles.Where(x => x.Id == 45).FirstOrDefault();
        HorarioDetalle[] results = await MergeRangeAsync(originalEntities, entidad);
        List<long> ids = results.Select(x => x.Id).ToList();
        List<HorarioDetalle> completed = await GetByIdsAsync(ids);
        HorarioDetalle hd = context.HorarioDetalles.Where(x => x.Id == 45).FirstOrDefault();
        if (completed.Count != results.Length) throw new Exception("Error al fusionar HorarioDetalle: no se encontraron todos los registros esperados.");
        return GetOrderedArrayFrom(completed, results);
    }
}
