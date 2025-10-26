using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.rrhh
{
    public class CargoRepository : CachedRepositoryBase<Cargo, int>, ICargoRepository
    {
        public CargoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        public async Task<Cargo> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Cargo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Cargo>> ObtenerActivos() => (await GetCachedListAsync()).Where(c => c.Estado).ToList();
        public Task<Cargo> Agregar(Cargo entry) => AddAsync(entry);
        public async Task<Cargo> Modificar(Cargo entry)
        {
            var response = await UpdateAsync(entry);
            return await ObtenerPorId(response.Id);
        }
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
