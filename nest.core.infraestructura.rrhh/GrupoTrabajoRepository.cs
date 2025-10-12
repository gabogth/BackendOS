using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh
{
    public class GrupoTrabajoRepository : CrudRepositoryBase<GrupoTrabajo, GrupoTrabajoCrearDto, long>, IGrupoTrabajoRepository
    {
        public GrupoTrabajoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<GrupoTrabajo> Query() => context.Set<GrupoTrabajo>()
            .AsNoTracking()
            .Include(g => g.GrupoTrabajoPersonas)
                .ThenInclude(p => p.Persona);

        public Task<GrupoTrabajo> ObtenerPorId(long id) => GetByIdAsync(id);
        public Task<List<GrupoTrabajo>> ObtenerTodos() => GetAllAsync();
        public Task<List<GrupoTrabajo>> ObtenerActivos() => Query().Where(g => g.Estado).ToListAsync();
        public async Task<GrupoTrabajo> Agregar(GrupoTrabajoCrearDto entry) => await AddAsync(entry);
        public async Task<GrupoTrabajo> Modificar(long id, GrupoTrabajoCrearDto entry) => await UpdateAsync(id, entry);
        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
