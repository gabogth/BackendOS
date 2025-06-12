using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.corporativo
{
    public class EstructuraOrganizacionalTipoRepository : CachedRepositoryBase<EstructuraOrganizacionalTipo, EstructuraOrganizacionalTipoCrearDto, int>, IEstructuraOrganizacionalTipoRepository
    {
        public EstructuraOrganizacionalTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<EstructuraOrganizacionalTipo> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<EstructuraOrganizacionalTipo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<EstructuraOrganizacionalTipo>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Estado).ToList();
        public Task<EstructuraOrganizacionalTipo> Agregar(EstructuraOrganizacionalTipoCrearDto dto) => AddAsync(dto);
        public Task<EstructuraOrganizacionalTipo> Modificar(int id, EstructuraOrganizacionalTipoCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
