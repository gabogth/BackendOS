using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.rrhh
{
    public class CargoRepository : CachedRepositoryBase<Cargo, CargoCrearDto, int>, ICargoRepository
    {
        public CargoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        public async Task<Cargo> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Cargo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Cargo>> ObtenerActivos() => (await GetCachedListAsync()).Where(c => c.Estado).ToList();
        public Task<Cargo> Agregar(CargoCrearDto dto) => AddAsync(dto);
        public Task<Cargo> Modificar(int id, CargoCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
