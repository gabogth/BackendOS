using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using nest.core.dominio.Cache;
using nest.core.dominio.General.DistritoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using System.Linq;

namespace nest.core.infraestructura.general
{
    public class DistritoRepository : CachedRepositoryBase<Distrito, int>, IDistritoRepository
    {
        public DistritoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<Distrito> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Distrito>> ObtenerTodos() => await GetAllAsync();
        public async Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);
        public async Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);
        public async Task<Distrito> Agregar(Distrito dto) => await AddAsync(dto);
        public async Task<Distrito> Modificar(Distrito dto) => await UpdateAsync(dto);
        public async Task Eliminar(int id) => await DeleteAsync(id);
    }
}
