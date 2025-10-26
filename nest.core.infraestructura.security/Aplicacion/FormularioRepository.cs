using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.security.Aplicacion
{
    public class FormularioRepository : CachedRepositoryBase<Formulario, int>, IFormularioRepository
    {
        public FormularioRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache)
        {
        }

        public async Task<Formulario> ObtenerPorId(int id) =>
            await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<Formulario>(id.ToString());

        public async Task<List<Formulario>> ObtenerPorModuloId(int moduloId) =>
            await context.Formulario
                .AsNoTracking()
                .Where(x => x.ModuloId == moduloId)
                .ToListAsync();

        public async Task<List<Formulario>> ObtenerTodos() => await GetAllAsync();

        public async Task<List<Formulario>> ObtenerPorUnaPropiedad(Dictionary<string, object?> filtros)
        {
            IQueryable<Formulario> query = context.Formulario.AsQueryable();
            foreach (var filtro in filtros)
            {
                if (string.IsNullOrWhiteSpace(filtro.Key))
                    continue;

                var propiedad = typeof(Formulario).GetProperty(filtro.Key);
                if (propiedad is null)
                    continue;

                var valorFiltro = filtro.Value?.ToString();
                if (!string.IsNullOrEmpty(valorFiltro))
                    query = query.Where(p => EF.Property<object>(p, filtro.Key).ToString()!.Contains(valorFiltro));
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<List<Formulario>> ObtenerPorRolId(string roleId)
        {
            List<string> claims = await context.RoleClaims.Where(x => x.RoleId == roleId).Select(x => x.ClaimType).ToListAsync();
            return await context.Formulario.Where(x => claims.Contains(x.ClaimType)).ToListAsync();
        }

        public async Task<Formulario> Agregar(Formulario entry)
        {
            entry.ParentId = entry.ParentId == 0 ? null : entry.ParentId;
            return await AddAsync(entry);
        }

        public async Task<Formulario> Modificar(Formulario entry)
        {
            entry.ParentId = entry.ParentId == 0 ? null : entry.ParentId;
            return await UpdateAsync(entry);
        }

        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
