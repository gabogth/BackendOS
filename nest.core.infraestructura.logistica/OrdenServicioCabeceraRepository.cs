using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica.OrdenServicio;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.logistica
{
    public class OrdenServicioCabeceraRepository : IOrdenServicioCabeceraRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public OrdenServicioCabeceraRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<OrdenServicioCabecera> ObtenerPorId(int id) =>
            await context.OrdenServicioCabecera.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<OrdenServicioCabecera>> ObtenerTodos() =>
            await context.OrdenServicioCabecera.ToListAsync();

        public async Task<OrdenServicioCabecera> Agregar(OrdenServicioCabeceraCrearDto entry)
        {
            var entity = mapper.Map<OrdenServicioCabecera>(entry);
            await context.OrdenServicioCabecera.AddAsync(entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }

        public async Task<OrdenServicioCabecera> Modificar(int id, OrdenServicioCabeceraCrearDto entry)
        {
            var existente = await context.OrdenServicioCabecera.FirstOrDefaultAsync(x => x.Id == id);
            if (existente == null)
                throw new RegistroNoEncontradoException<OrdenServicioCabecera>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }

        public async Task Eliminar(int id)
        {
            var existente = await context.OrdenServicioCabecera.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<OrdenServicioCabecera>(id);
            context.OrdenServicioCabecera.Remove(existente);
            await context.SaveChangesAsync();
        }
    }
}
