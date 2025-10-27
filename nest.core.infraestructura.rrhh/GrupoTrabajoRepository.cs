using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh
{
    public class GrupoTrabajoRepository : CrudRepositoryBase<GrupoTrabajo, long>, IGrupoTrabajoRepository
    {
        public GrupoTrabajoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<GrupoTrabajo> Query() => context.Set<GrupoTrabajo>()
            .AsNoTracking()
            .Include(g => g.GrupoTrabajoPersonas)
                .ThenInclude(p => p.Persona);

        public async Task<GrupoTrabajo> ObtenerPorId(long id) =>
            await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<GrupoTrabajo>(id.ToString());
        public Task<List<GrupoTrabajo>> ObtenerTodos() => GetAllAsync();
        public Task<List<GrupoTrabajo>> ObtenerActivos() => Query().Where(g => g.Estado).ToListAsync();
        public async Task<GrupoTrabajo> Agregar(GrupoTrabajo entry)
        {
            var entity = await AddAsync(entry);
            return await ObtenerPorId(entity.Id);
        }

        public async Task<GrupoTrabajo> Modificar(GrupoTrabajo entry)
        {
            await UpdateAsync(entry);
            return await ObtenerPorId(entry.Id);
        }
        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
