using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Modulo.Repository;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.security.Aplicacion
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public ModuloRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Modulo> ObtenerPorId(int id)
        {
            return await context.Modulo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Modulo>> ObtenerTodos()
        {
            return await context.Modulo.ToListAsync();
        }
        public async Task<List<Modulo>> ObtenerPorUnaPropiedad(Dictionary<string, object> filtros) 
        {
            IQueryable<Modulo> query = context.Modulo;
            foreach (var filtro in filtros)
            {
                var propiedad = typeof(Modulo).GetProperty(filtro.Key);
                if (propiedad != null)
                {
                    var valorFiltro = filtro.Value?.ToString();
                    if (!string.IsNullOrEmpty(valorFiltro))
                        query = query.Where(p => EF.Property<object>(p, filtro.Key).ToString().Contains(valorFiltro));
                }
            }
            return await query.ToListAsync();
        }
        public async Task<Modulo> Agregar(ModuloCrearDto entry)
        {
            Modulo entryFine = mapper.Map<Modulo>(entry);
            await context.Modulo.AddAsync(entryFine);
            await context.SaveChangesAsync();
            await context.Entry(entryFine).ReloadAsync();
            return entryFine;
        }
        public async Task<Modulo> Modificar(int id, ModuloCrearDto entry)
        {
            var find = await context.Modulo.FirstOrDefaultAsync(x => x.Id == id);
            if (find == null)
                throw new RegistroNoEncontradoException<Modulo>(id);
            Modulo entryFine = mapper.Map<Modulo>(entry);
            entryFine.FechaModificacion = DateTime.Now;
            await context.SaveChangesAsync();
            await context.Entry(entryFine).ReloadAsync();
            return entryFine;
        }
        public async Task Eliminar(int id)
        {
            int registrosAfectados = await context.Modulo.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (registrosAfectados < 1)
                throw new RegistroNoEncontradoException<Modulo>(id);
            context.SaveChanges();
        }
    }
}
