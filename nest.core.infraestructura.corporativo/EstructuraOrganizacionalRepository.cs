using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.corporativo
{
    public class EstructuraOrganizacionalRepository : CachedRepositoryBase<EstructuraOrganizacional, EstructuraOrganizacionalCrearDto, int>, IEstructuraOrganizacionalRepository
    {
        public EstructuraOrganizacionalRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<EstructuraOrganizacional> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<EstructuraOrganizacional>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<EstructuraOrganizacional>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Estado).ToList();
        public async Task<EstructuraOrganizacional> Agregar(EstructuraOrganizacionalCrearDto entidad) => await AddAsync(entidad);
        public async Task<EstructuraOrganizacional> Modificar(int id, EstructuraOrganizacionalCrearDto entidad) => await UpdateAsync(id, entidad);
        public async Task Eliminar(int id) => await DeleteAsync(id);

        
    }
}
