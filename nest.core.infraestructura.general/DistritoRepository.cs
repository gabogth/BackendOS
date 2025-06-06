using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.DistritoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class DistritoRepository : IDistritoRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public DistritoRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Distrito> ObtenerPorId(int id) =>
            await context.Distrito.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<Distrito>> ObtenerTodos() =>
            await context.Distrito.ToListAsync();
        public async Task<List<Distrito>> ObtenerActivos() =>
            await context.Distrito.ToListAsync();
        public async Task<Distrito> Agregar(DistritoCrearDto entry)
        {
            var entidad = mapper.Map<Distrito>(entry);
            context.Distrito.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }
        public async Task<Distrito> Modificar(int id, DistritoCrearDto entry)
        {
            var existente = await context.Distrito.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Distrito>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(int id)
        {
            var existente = await context.Distrito.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Distrito>(id);
            context.Distrito.Remove(existente);
            context.SaveChanges();
        }
    }
}
