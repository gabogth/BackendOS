using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.patrimonial
{
    public class ActivoRepository : CachedRepositoryBase<Activo, long>, IActivoRepository
    {
        public ActivoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache)
            : base(context, mapper, cache)
        {
        }

        public Task<Activo> Agregar(Activo dto) => AddAsync(dto);
        public Task Eliminar(long id) => DeleteAsync(id);
        public Task<Activo> Modificar(Activo dto) => UpdateAsync(dto);
        public async Task<Activo> ObtenerPorId(long id) => await GetByIdAsync(id);
        public async Task<List<Activo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Activo>> ObtenerActivos() => await GetAllAsync();
    }
}
