using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Costos.CentroDeCostosEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.costos
{
    public class CentroDeCostosRepository : CachedRepositoryBase<CentroDeCostos, int>, ICentroDeCostosRepository
    {
        public CentroDeCostosRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        protected override IQueryable<CentroDeCostos> Query() => context.Set<CentroDeCostos>()
            .AsNoTracking()
            .Include(x => x.Children);

        public Task<CentroDeCostos> ObtenerPorId(int id) => GetByIdAsync(id);

        public Task<List<CentroDeCostos>> ObtenerTodos() => GetAllAsync();

        public async Task<List<CentroDeCostos>> ObtenerActivos() => (await GetAllAsync()).Where(x => x.Activo).ToList();

        public Task<CentroDeCostos> Agregar(CentroDeCostos entry) => AddAsync(entry);

        public Task<CentroDeCostos> Modificar(CentroDeCostos entry) => UpdateAsync(entry);

        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
