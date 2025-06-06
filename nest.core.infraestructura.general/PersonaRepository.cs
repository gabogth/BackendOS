using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.PersonaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;

        public PersonaRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Persona> ObtenerPorId(int id)
        {
            return await context.Persona.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Persona>> ObtenerTodos()
        {
            return await context.Persona.ToListAsync();
        }

        public async Task<List<Persona>> ObtenerActivos()
        {
            return await context.Persona.Where(p => p.Estado).ToListAsync();
        }

        public async Task<Persona> Agregar(PersonaCrearDto entry)
        {
            var entidad = mapper.Map<Persona>(entry);
            context.Persona.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }

        public async Task<Persona> Modificar(int id, PersonaCrearDto entry)
        {
            var existente = await context.Persona.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Persona>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }

        public async Task Eliminar(int id)
        {
            var existente = await context.Persona.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Persona>(id);
            context.Persona.Remove(existente);
            context.SaveChanges();
        }
    }
}
