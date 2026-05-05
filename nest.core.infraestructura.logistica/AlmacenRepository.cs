using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using nest.core.dominio.Cache;
using nest.core.dominio.General;
using nest.core.dominio.Logistica.AlmacenEN;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.DataLoader;

namespace nest.core.infraestructura.logistica
{
    public class AlmacenRepository : CachedRepositoryBase<Almacen, int>, IAlmacenRepository
    {
        public AlmacenRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        public async Task<Almacen> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Almacen>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Almacen>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Activo).ToList();
        public async Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoaderLw.LoadAsync(Query(), options, cancellationToken);
        public async Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoaderLw.LoadAsync(Query().Where(x => x.Activo), options, cancellationToken);
        public Task<Almacen> Agregar(Almacen dto) => AddAsync(dto);
        public Task<Almacen> Modificar(Almacen dto) => UpdateAsync(dto);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
