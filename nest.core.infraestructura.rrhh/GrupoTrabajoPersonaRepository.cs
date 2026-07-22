using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh;

public class GrupoTrabajoPersonaRepository : CrudRepositoryBase<GrupoTrabajoPersona, long>, IGrupoTrabajoPersonaRepository
{
    public GrupoTrabajoPersonaRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<GrupoTrabajoPersona> Query() => context.Set<GrupoTrabajoPersona>()
        .AsNoTracking()
        .Include(p => p.Persona)
        .Include(p => p.GrupoTrabajo);

    public async Task<GrupoTrabajoPersona> ObtenerPorId(long id)
    {
        return await Query().FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new RegistroNoEncontradoException<GrupoTrabajoPersona>(id.ToString());
    }

    private async Task<List<GrupoTrabajoPersona>> ObtenerPorIds(List<long> ids)
    {
        return await Query().Where(p => ids.Contains(p.Id)).ToListAsync();
    }

    public Task<List<GrupoTrabajoPersona>> ObtenerTodos() => GetAllAsync();

    public Task<List<GrupoTrabajoPersona>> ObtenerPorGrupoTrabajo(long grupoTrabajoId) =>
        Query().Where(p => p.GrupoTrabajoId == grupoTrabajoId).ToListAsync();

    public async Task<GrupoTrabajoPersona> Agregar(GrupoTrabajoPersona entry)
    {
        var persona = await AddAsync(entry);
        return await ObtenerPorId(persona.Id);
    }

    public async Task<GrupoTrabajoPersona[]> AgregarRange(GrupoTrabajoPersona[] entries)
    {
        var registros = await AddRangeAsync(entries);
        List<GrupoTrabajoPersona> returnValues = await ObtenerPorIds(registros.Select(x => x.Id).ToList());
        return GetOrderedArrayFrom(returnValues, registros);
    }

    public async Task<GrupoTrabajoPersona> Modificar(GrupoTrabajoPersona entry)
    {
        await UpdateAsync(entry);
        return await ObtenerPorId(entry.Id);
    }

    public async Task<GrupoTrabajoPersona[]> ModificarRange(GrupoTrabajoPersona[] entries)
    {
        var registros = await UpdateRangeAsync(entries);
        List<GrupoTrabajoPersona> returnValues = await ObtenerPorIds(registros.Select(x => x.Id).ToList());
        return GetOrderedArrayFrom(returnValues, registros);
    }

    public async Task<GrupoTrabajoPersona[]> FusionarRange(GrupoTrabajoPersona[] original, GrupoTrabajoPersona[] entries)
    {
        var registros = await MergeRangeAsync(original, entries);
        List<GrupoTrabajoPersona> returnValues = await ObtenerPorIds(registros.Select(x => x.Id).ToList());
        return GetOrderedArrayFrom(returnValues, registros);
    }

    public Task Eliminar(long id) => DeleteAsync(id);
    public Task EliminarRange(long[] ids) => DeleteRangeAsync(ids);
    public async Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);
    public async Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);
}
