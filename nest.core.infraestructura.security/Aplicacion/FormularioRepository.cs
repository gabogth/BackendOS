using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.DataLoader;
using nest.core.infrastructura.utils.Excepciones;
using System.Linq;

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

        public async Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoaderLw.LoadAsync(Query(), options, cancellationToken);
        public async Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoaderLw.LoadAsync(Query().Where(x => x.Estado), options, cancellationToken);

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

        public async Task<List<Formulario>> ObtenerPorUserId(string userId)
        {
            List<string> tempClaims = new List<string>();
            var roleIds = await context.UserRoles.Where(x => x.UserId == userId).Select(y => y.RoleId).ToListAsync();
            var currentRoleClaims = await context.RoleClaims.Where(x => roleIds.Contains(x.RoleId)).Select(x => x.ClaimType).ToListAsync();
            var currentUserClaims = await context.UserClaims.Where(x => x.UserId == userId).Select(x => x.ClaimType).ToListAsync();
            if(currentRoleClaims != null && currentRoleClaims.Count > 0)
                tempClaims.AddRange(currentRoleClaims);
            if(currentUserClaims != null && currentUserClaims.Count > 0)
                tempClaims.AddRange(currentUserClaims);
            var finalClaims = tempClaims.Distinct();
            if(!finalClaims.Any())
                return Array.Empty<Formulario>().ToList();
            List<Formulario> allForms = await this.GetAllAsync();
            Dictionary<int, Formulario> allMenuId = allForms.ToDictionary(x => x.Id);
            Dictionary<int, Formulario> customMenu = new Dictionary<int, Formulario>();
            List<int> finalIds = allForms.Where(x => finalClaims.Any(f => x.ClaimType == f)).Select(x => x.Id).ToList();

            Dictionary<string, Formulario> formIndex = new Dictionary<string, Formulario>();
            foreach (var form in finalIds)
                GetParents(form, allMenuId, customMenu);
            return customMenu.Values.ToList();
        }

        private void GetParents(int claimForm, Dictionary<int, Formulario> allMenuId, Dictionary<int, Formulario> customMenu)
        {
            if (!allMenuId.ContainsKey(claimForm))
                return;
            var currForm = allMenuId[claimForm];
            if (!customMenu.ContainsKey(claimForm))
                customMenu.Add(claimForm, currForm);
            if (currForm.ParentId == null || currForm.ParentId == 0)
                return;
            var parentForm = allMenuId[currForm.ParentId.Value];
            GetParents(parentForm.Id, allMenuId, customMenu);
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
