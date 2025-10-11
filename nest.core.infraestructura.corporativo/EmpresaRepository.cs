using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Corporativo.Empresa;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.corporativo
{
    public class EmpresaRepository : CachedRepositoryBase<Empresa, EmpresaCrearDto, int>, IEmpresaRepository
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
        public async Task<List<Empresa>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Empresa>> ObtenerActivos() => (await GetCachedListAsync()).Where(x => x.Estado).ToList();
        public async Task<Empresa> Agregar(EmpresaCrearDto entry) => await AddAsync(entry);
        public async Task<Empresa> Modificar(int id, EmpresaCrearDto entry) => await UpdateAsync(id, entry);
        public async Task Eliminar(int id)
        {
            await DeleteAsync(id);
            await InvalidateCacheAsync();
        }
    }
}

