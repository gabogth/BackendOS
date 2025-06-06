using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public ProvinciaRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Provincia> ObtenerPorId(int id) =>
            await context.Provincia.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<Provincia>> ObtenerTodos() =>
            await context.Provincia.ToListAsync();
        public async Task<List<Provincia>> ObtenerActivos() =>
            await context.Provincia.ToListAsync();
        public async Task<Provincia> Agregar(ProvinciaCrearDto entry)
        {
            var entidad = mapper.Map<Provincia>(entry);
            context.Provincia.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }
        public async Task<Provincia> Modificar(int id, ProvinciaCrearDto entry)
        {
            var existente = await context.Provincia.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Provincia>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(int id)
        {
            var existente = await context.Provincia.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Provincia>(id);
            context.Provincia.Remove(existente);
            context.SaveChanges();
        }
    }
}
