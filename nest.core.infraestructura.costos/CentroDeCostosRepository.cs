using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.Costos.CentroDeCostosEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using System.Data.Entity;

namespace nest.core.infraestructura.costos
{
    public class CentroDeCostosRepository : CachedRepositoryBase<CentroDeCostos, CentroDeCostosCrearDto, int>, ICentroDeCostosRepository
    {
        public CentroDeCostosRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        protected override IQueryable<CentroDeCostos> Query() => context.Set<CentroDeCostos>()
            .AsNoTracking()
            .Include(x => x.Children);
        public async Task<CentroDeCostos> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<CentroDeCostos>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<CentroDeCostos>> ObtenerActivos() => (await GetAllAsync()).Where(x => x.Activo).ToList();
        public Task<CentroDeCostos> Agregar(CentroDeCostosCrearDto dto) => AddAsync(dto);
        public Task<CentroDeCostos> Modificar(int id, CentroDeCostosCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
