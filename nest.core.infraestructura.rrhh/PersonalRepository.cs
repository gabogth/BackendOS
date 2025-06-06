using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public PersonalRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Personal> ObtenerPorId(int id) =>
            await context.Personales.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<Personal>> ObtenerTodos() =>
            await context.Personales.ToListAsync();
        public async Task<List<Personal>> ObtenerActivos() =>
            await context.Personales.ToListAsync();
        public async Task<Personal> Agregar(PersonalCrearDto entry)
        {
            var entity = mapper.Map<Personal>(entry);
            context.Personales.Add(entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }
        public async Task<Personal> Modificar(int id, PersonalCrearDto entry)
        {
            var existente = await context.Personales.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Personal>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(int id)
        {
            var existente = await context.Personales.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Personal>(id);
            context.Personales.Remove(existente);
            context.SaveChanges();
        }
    }
}
