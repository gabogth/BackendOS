using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General;
using nest.core.dominio.Logistica.AlmacenEN;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.logistica
{
    public class AlmacenRepository : IAlmacenRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public AlmacenRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Almacen> ObtenerPorId(int id) => await context.Almacen.Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<List<Almacen>> ObtenerTodos() => await context.Almacen.ToListAsync();
        public async Task<List<Almacen>> ObtenerActivos() => await context.Almacen.Where(x => x.Activo).ToListAsync();
        public async Task<Almacen> Agregar(AlmacenCrearDto entry)
        {
            Almacen entryFine = mapper.Map<Almacen>(entry);
            await context.Almacen.AddAsync(entryFine);
            await context.SaveChangesAsync();
            await context.Entry(entryFine).ReloadAsync();
            return entryFine;
        }
        public async Task<Almacen> Modificar(int id, AlmacenCrearDto entry)
        {
            Almacen find = await context.Almacen.FirstOrDefaultAsync(x => x.Id == id);
            if (find == null)
                throw new RegistroNoEncontradoException<Almacen>(id);
            mapper.Map(entry, find);
            await context.SaveChangesAsync();
            await context.Entry(find).ReloadAsync();
            return find;
        }
        public async Task Eliminar(int id)
        {
            int registrosAfectados = await context.Almacen.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (registrosAfectados < 1)
                throw new RegistroNoEncontradoException<Almacen>(id);
            context.SaveChanges();
        }
    }
}
