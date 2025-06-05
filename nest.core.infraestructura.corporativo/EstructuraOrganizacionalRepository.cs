using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.corporativo
{
    public class EstructuraOrganizacionalRepository : IEstructuraOrganizacionalRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;

        public EstructuraOrganizacionalRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<EstructuraOrganizacional> ObtenerPorId(int id)
        {
            return await context.EstructuraOrganizacional
                .Include(x => x.EstructuraOrganizacionalTipo)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EstructuraOrganizacional>> ObtenerTodos()
        {
            return await context.EstructuraOrganizacional
                .Include(x => x.EstructuraOrganizacionalTipo)
                .ToListAsync();
        }

        public async Task<List<EstructuraOrganizacional>> ObtenerActivos()
        {
            return await context.EstructuraOrganizacional
                .Include(x => x.EstructuraOrganizacionalTipo)
                .Where(x => x.Estado)
                .ToListAsync();
        }

        public async Task<EstructuraOrganizacional> Agregar(EstructuraOrganizacionalCrearDto entry)
        {
            var entidad = mapper.Map<EstructuraOrganizacional>(entry);
            entidad.FechaRegistro = DateTime.UtcNow;
            context.EstructuraOrganizacional.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
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
            return existente;
        }

        public async Task Eliminar(int id)
        {
            var existente = await context.EstructuraOrganizacional.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<EstructuraOrganizacional>(id);
            context.EstructuraOrganizacional.Remove(existente);
            context.SaveChanges();
        }
    }
}
