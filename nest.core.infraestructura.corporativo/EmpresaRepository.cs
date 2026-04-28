using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Corporativo.Empresa;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.corporativo
{
    public class EmpresaRepository : CachedRepositoryBase<Empresa, int>, IEmpresaRepository
    {
        public EmpresaRepository(NestDbContext context, IMapper mapper, ICacheRepository cache)
            : base(context, mapper, cache)
        {
        }
        protected override IQueryable<Empresa> Query()
        {
            return context.Set<Empresa>()
                .AsNoTracking()
                .OrderBy(x => x.Nombre);
        }
        public async Task<Empresa?> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);
        public async Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query().Where(x => x.Estado), options, cancellationToken);
        public async Task<List<Empresa>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Empresa>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Estado).ToList();
        public async Task<Empresa> Agregar(Empresa entidad) => await AddAsync(entidad);
        public async Task<Empresa> Modificar(Empresa entidad) => await UpdateAsync(entidad);
        public async Task Eliminar(int id) => await DeleteAsync(id);
    }
}
