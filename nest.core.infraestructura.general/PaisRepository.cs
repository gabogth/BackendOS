using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.PaisEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class PaisRepository : IPaisRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public PaisRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Pais> ObtenerPorId(int id) =>
            await context.Pais.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<Pais>> ObtenerTodos() =>
            await context.Pais.ToListAsync();
        public async Task<List<Pais>> ObtenerActivos() =>
            await context.Pais.ToListAsync();
        public async Task<Pais> Agregar(PaisCrearDto entry)
        {
            var entidad = mapper.Map<Pais>(entry);
            context.Pais.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }
        public async Task<Pais> Modificar(int id, PaisCrearDto entry)
        {
            var existente = await context.Pais.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Pais>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(int id)
        {
            var existente = await context.Pais.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Pais>(id);
            context.Pais.Remove(existente);
            context.SaveChanges();
        }
    }
}
