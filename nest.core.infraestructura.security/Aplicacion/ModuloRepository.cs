using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Modulo.Repository;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.infrastructura.utils.Excepciones;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.security.Aplicacion
{
    public class ModuloRepository : CachedRepositoryBase<Modulo, ModuloCrearDto, int>, IModuloRepository
    {
        public ModuloRepository(NestDbContext context, IMapper mapper, ICacheRepository cache)
            : base(context, mapper, cache) { }
        public async Task<Modulo> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Modulo>> ObtenerTodos() => await GetAllAsync();
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
        public async Task<Modulo> Agregar(ModuloCrearDto entry) => await AddAsync(entry);
        public async Task<Modulo> Modificar(int id, ModuloCrearDto entry)
        {
            var entidad = await context.Modulo.FindAsync(id) ?? throw new RegistroNoEncontradoException<Modulo>(id);
            mapper.Map(entry, entidad);
            entidad.FechaModificacion = DateTime.Now;
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            await InvalidateCacheAsync();
            return entidad;
        }
        public async Task Eliminar(int id) => await DeleteAsync(id);
    }
}
