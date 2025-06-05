using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Legal.ContratoTipoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.legal
{
    public class ContratoTipoRepository : IContratoTipoRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public ContratoTipoRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ContratoTipo> ObtenerPorId(byte id) => await context.ContratoTipo.Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<List<ContratoTipo>> ObtenerTodos() => await context.ContratoTipo.ToListAsync();
        public async Task<ContratoTipo> Agregar(ContratoTipoCrearDto entry)
        {
            var entity = mapper.Map<ContratoTipo>(entry);
            context.ContratoTipo.Add(entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }
        public async Task<ContratoTipo> Modificar(byte id, ContratoTipoCrearDto entry)
        {
            var existente = await context.ContratoTipo.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<ContratoTipo>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(byte id)
        {
            var existente = await context.ContratoTipo.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<ContratoTipo>(id);
            context.ContratoTipo.Remove(existente);
            context.SaveChanges();
        }
    }
}
