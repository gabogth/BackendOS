using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.contabilidad
{
    public class CuentaContableTipoRepository : CachedRepositoryBase<CuentaContableTipo, CuentaContableTipoCrearDto, int>, ICuentaContableTipoRepository
    {
        public CuentaContableTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        protected override IQueryable<CuentaContableTipo> Query() => context.Set<CuentaContableTipo>().AsNoTracking();
        public Task<CuentaContableTipo> ObtenerPorId(int id) => GetByIdAsync(id);
        public Task<List<CuentaContableTipo>> ObtenerTodos() => GetAllAsync();
        public async Task<List<CuentaContableTipo>> ObtenerActivos() => (await GetAllAsync()).Where(x => x.Activo).ToList();
        public Task<CuentaContableTipo> Agregar(CuentaContableTipoCrearDto entry) => AddAsync(entry);
        public Task<CuentaContableTipo> Modificar(int id, CuentaContableTipoCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
