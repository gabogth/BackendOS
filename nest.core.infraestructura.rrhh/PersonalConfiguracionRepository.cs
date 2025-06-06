using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.PersonalConfiguracionEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class PersonalConfiguracionRepository : IPersonalConfiguracionRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public PersonalConfiguracionRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<PersonalConfiguracion> ObtenerPorId(int id) =>
            await context.PersonalesConfiguracion.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<PersonalConfiguracion>> ObtenerTodos() =>
            await context.PersonalesConfiguracion.ToListAsync();
        public async Task<List<PersonalConfiguracion>> ObtenerActivos() =>
            await context.PersonalesConfiguracion.ToListAsync();
        public async Task<PersonalConfiguracion> Agregar(PersonalConfiguracionCrearDto entry)
        {
            var entity = mapper.Map<PersonalConfiguracion>(entry);
            context.PersonalesConfiguracion.Add(entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }
        public async Task<PersonalConfiguracion> Modificar(int id, PersonalConfiguracionCrearDto entry)
        {
            var existente = await context.PersonalesConfiguracion.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<PersonalConfiguracion>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(int id)
        {
            var existente = await context.PersonalesConfiguracion.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<PersonalConfiguracion>(id);
            context.PersonalesConfiguracion.Remove(existente);
            context.SaveChanges();
        }
    }
}
