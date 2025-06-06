using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.SexoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class SexoRepository : ISexoRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public SexoRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Sexo> ObtenerPorId(byte id) =>
            await context.Sexos.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<Sexo>> ObtenerTodos() =>
            await context.Sexos.ToListAsync();
        public async Task<List<Sexo>> ObtenerActivos() =>
            await context.Sexos.ToListAsync();
        public async Task<Sexo> Agregar(SexoCrearDto entry)
        {
            var entidad = mapper.Map<Sexo>(entry);
            context.Sexos.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }
        public async Task<Sexo> Modificar(byte id, SexoCrearDto entry)
        {
            var existente = await context.Sexos.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Sexo>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(byte id)
        {
            var existente = await context.Sexos.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Sexo>(id);
            context.Sexos.Remove(existente);
            context.SaveChanges();
        }
    }
}
