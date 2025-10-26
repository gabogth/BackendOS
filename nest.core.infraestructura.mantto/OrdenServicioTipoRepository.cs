using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.mantto
{
    public class OrdenServicioTipoRepository : CachedRepositoryBase<OrdenServicioTipo, short>, IOrdenServicioTipoRepository
    {
        public OrdenServicioTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        public async Task<OrdenServicioTipo> ObtenerPorId(short id) => await GetByIdAsync(id);
        public async Task<List<OrdenServicioTipo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<OrdenServicioTipo>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Estado).ToList();
        public Task<OrdenServicioTipo> Agregar(OrdenServicioTipo entity) => AddAsync(entity);
        public Task<OrdenServicioTipo> Modificar(OrdenServicioTipo entity) => UpdateAsync(entity);
        public Task Eliminar(short id) => DeleteAsync(id);
    }
}
