using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.Mantto.LaborEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.mantto
{
    public class LaborRepository : CachedRepositoryBase<Labor, int>, ILaborRepository
    {
        public LaborRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        public async Task<Labor> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Labor>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Labor>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Activo).ToList();
        public Task<Labor> Agregar(Labor entry) => AddAsync(entry);
        public Task<Labor> Modificar(Labor entry) => UpdateAsync(entry);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
