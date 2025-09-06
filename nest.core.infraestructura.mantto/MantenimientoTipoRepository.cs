using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.mantto
{
    public class MantenimientoTipoRepository : CachedRepositoryBase<MantenimientoTipo, MantenimientoTipoCrearDto, short>, IMantenimientoTipoRepository
    {
        public MantenimientoTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        public async Task<MantenimientoTipo> ObtenerPorId(short id) => await GetByIdAsync(id);
        public async Task<List<MantenimientoTipo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<MantenimientoTipo>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Activo).ToList();
        public Task<MantenimientoTipo> Agregar(MantenimientoTipoCrearDto dto) => AddAsync(dto);
        public Task<MantenimientoTipo> Modificar(short id, MantenimientoTipoCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(short id) => DeleteAsync(id);
    }
}
