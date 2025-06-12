using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.infrastructura.utils.Excepciones;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.infraestructura.security.Aplicacion
{
    public class FormularioRepository: CachedRepositoryBase<Formulario, FormularioCrearDto, int>, IFormularioRepository
    {
        public FormularioRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache)
        {
        }
        public async Task<Formulario> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Formulario>> ObtenerPorModuloId(int moduloId)
        {
            return await context.Formulario.AsNoTracking().Where(x => x.ModuloId == moduloId).ToListAsync();
        }
        public async Task<List<Formulario>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Formulario>> ObtenerPorUnaPropiedad(Dictionary<string, object> filtros)
        {
            IQueryable<Formulario> query = context.Formulario;
            foreach (var filtro in filtros)
            {
                var propiedad = typeof(Formulario).GetProperty(filtro.Key);
                if (propiedad != null)
                {
                    var valorFiltro = filtro.Value?.ToString();
                    if (!string.IsNullOrEmpty(valorFiltro))
                        query = query.Where(p => EF.Property<object>(p, filtro.Key).ToString().Contains(valorFiltro));
                }
            }
            return await query.ToListAsync();
        }
        public async Task<List<Formulario>> ObtenerPorRolId(string roleId)
        {
            List<string> claims = await context.RoleClaims.Where(x => x.RoleId == roleId).Select(x => x.ClaimType).ToListAsync();
            return await context.Formulario.Where(x => claims.Contains(x.ClaimType)).ToListAsync();
        }
        public async Task<Formulario> Agregar(FormularioCrearDto entry)
        {
            entry.ParentId = entry.ParentId == 0 ? null : entry.ParentId;
            return await AddAsync(entry);
        }
        public async Task<Formulario> Modificar(int id, FormularioCrearDto entry)
        {
            var entidad = await context.Formulario.FindAsync(id) ?? throw new RegistroNoEncontradoException<Formulario>(id);
            mapper.Map(entry, entidad);
            entidad.FechaModificacion = DateTime.Now;
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            await InvalidateCacheAsync();
            return entidad;
        }
        public async Task Eliminar(int id)
        {
            await DeleteAsync(id);
        }
    }
}
