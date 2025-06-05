using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.corporativo
{
    public class EstructuraOrganizacionalTipoRepository : IEstructuraOrganizacionalTipoRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;

        public EstructuraOrganizacionalTipoRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<EstructuraOrganizacionalTipo> ObtenerPorId(int id)
        {
            return await context.EstructuraOrganizacionalTipo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EstructuraOrganizacionalTipo>> ObtenerTodos()
        {
            return await context.EstructuraOrganizacionalTipo.ToListAsync();
        }

        public async Task<List<EstructuraOrganizacionalTipo>> ObtenerActivos()
        {
            return await context.EstructuraOrganizacionalTipo.Where(x => x.Estado).ToListAsync();
        }

        public async Task<EstructuraOrganizacionalTipo> Agregar(EstructuraOrganizacionalTipoCrearDto entry)
        {
            var entidad = mapper.Map<EstructuraOrganizacionalTipo>(entry);
            context.EstructuraOrganizacionalTipo.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
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
            return existente;
        }

        public async Task Eliminar(int id)
        {
            var existente = await context.EstructuraOrganizacionalTipo.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<EstructuraOrganizacionalTipo>(id);
            context.EstructuraOrganizacionalTipo.Remove(existente);
            context.SaveChanges();
        }
    }
}
