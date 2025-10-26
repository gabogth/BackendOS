using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Modulo.Repository;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.security.Aplicacion
{
    public class ModuloRepository : CachedRepositoryBase<Modulo, int>, IModuloRepository
    {
        public ModuloRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache)
        {
        }

        public async Task<Modulo> ObtenerPorId(int id) =>
            await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<Modulo>(id.ToString());

        public async Task<List<Modulo>> ObtenerTodos() => await GetAllAsync();

        public async Task<List<Modulo>> ObtenerPorUnaPropiedad(Dictionary<string, object?> filtros)
        {
            IQueryable<Modulo> query = Query();
            foreach (var filtro in filtros)
            {
                if (string.IsNullOrWhiteSpace(filtro.Key))
                    continue;

                var propiedad = typeof(Modulo).GetProperty(filtro.Key);
                if (propiedad is null)
                    continue;

                var valorFiltro = filtro.Value?.ToString();
                if (!string.IsNullOrEmpty(valorFiltro))
                    query = query.Where(p => EF.Property<object>(p, filtro.Key).ToString()!.Contains(valorFiltro));
            }
            return await query.ToListAsync();
        }

        public Task<Modulo> Agregar(Modulo entry) => AddAsync(entry);

        public Task<Modulo> Modificar(Modulo entry) => UpdateAsync(entry);

        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
