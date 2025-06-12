using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General;
using nest.core.dominio.Logistica.AlmacenEN;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.logistica
{
    public class AlmacenRepository : CachedRepositoryBase<Almacen, AlmacenCrearDto, int>, IAlmacenRepository
    {
        public AlmacenRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        public async Task<Almacen> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Almacen>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Almacen>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Activo).ToList();
        public Task<Almacen> Agregar(AlmacenCrearDto dto) => AddAsync(dto);
        public Task<Almacen> Modificar(int id, AlmacenCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
