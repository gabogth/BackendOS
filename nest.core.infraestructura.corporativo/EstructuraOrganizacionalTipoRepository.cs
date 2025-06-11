using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.corporativo
{
    public class EstructuraOrganizacionalTipoRepository : CachedRepositoryBase<EstructuraOrganizacionalTipo>, IEstructuraOrganizacionalTipoRepository
    {
        private readonly IMapper mapper;

        public EstructuraOrganizacionalTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, cache)
        {
            this.mapper = mapper;
        }

        public async Task<EstructuraOrganizacionalTipo> ObtenerPorId(int id) =>
            (await GetCachedListAsync()).FirstOrDefault(x => x.Id == id);

        public async Task<List<EstructuraOrganizacionalTipo>> ObtenerTodos() =>
            await GetCachedListAsync();

        public async Task<List<EstructuraOrganizacionalTipo>> ObtenerActivos() =>
            (await GetCachedListAsync()).Where(x => x.Estado).ToList();

        public async Task<EstructuraOrganizacionalTipo> Agregar(EstructuraOrganizacionalTipoCrearDto entry)
        {
            var entidad = mapper.Map<EstructuraOrganizacionalTipo>(entry);
            context.EstructuraOrganizacionalTipo.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            await InvalidateCacheAsync();
            return entidad;
        }

        public async Task<EstructuraOrganizacionalTipo> Modificar(int id, EstructuraOrganizacionalTipoCrearDto entry)
        {
            var existente = await context.EstructuraOrganizacionalTipo.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<EstructuraOrganizacionalTipo>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            await InvalidateCacheAsync();
            return existente;
        }

        public async Task Eliminar(int id)
        {
            var existente = await context.EstructuraOrganizacionalTipo.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<EstructuraOrganizacionalTipo>(id);
            context.EstructuraOrganizacionalTipo.Remove(existente);
            await context.SaveChangesAsync();
            await InvalidateCacheAsync();
        }
    }
}
