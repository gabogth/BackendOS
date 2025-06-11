using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.corporativo
{
    public class EstructuraOrganizacionalRepository : CachedRepositoryBase<EstructuraOrganizacional>, IEstructuraOrganizacionalRepository
    {
        private readonly IMapper mapper;

        public EstructuraOrganizacionalRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, cache)
        {
            this.mapper = mapper;
        }
        protected override IQueryable<EstructuraOrganizacional> Query() =>
            base.Query().Include(x => x.EstructuraOrganizacionalTipo);


        public async Task<List<EstructuraOrganizacional>> ObtenerTodos() => await GetCachedListAsync();
        public async Task<EstructuraOrganizacional> ObtenerPorId(int id) => (await GetCachedListAsync()).FirstOrDefault(x => x.Id == id);
        public async Task<List<EstructuraOrganizacional>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Estado).ToList();

        public async Task<EstructuraOrganizacional> Agregar(EstructuraOrganizacionalCrearDto entry)
        {
            var entidad = mapper.Map<EstructuraOrganizacional>(entry);
            entidad.FechaRegistro = DateTime.UtcNow;
            context.EstructuraOrganizacional.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            await InvalidateCacheAsync();
            return entidad;
        }

        public async Task<EstructuraOrganizacional> Modificar(int id, EstructuraOrganizacionalCrearDto entry)
        {
            var existente = await context.EstructuraOrganizacional.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<EstructuraOrganizacional>(id);
            mapper.Map(entry, existente);
            existente.FechaModificacion = DateTime.UtcNow;
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            await InvalidateCacheAsync();
            return existente;
        }

        public async Task Eliminar(int id)
        {
            var existente = await context.EstructuraOrganizacional.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<EstructuraOrganizacional>(id);
            context.EstructuraOrganizacional.Remove(existente);
            await context.SaveChangesAsync();
            await InvalidateCacheAsync();
        }
    }
}
