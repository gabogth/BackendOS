using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.PaisEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class PaisRepository : CachedRepositoryBase<Pais, int>, IPaisRepository
    {
        public PaisRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<Pais> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Pais>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Pais>> ObtenerActivos() => await GetAllAsync();
        public Task<Pais> Agregar(Pais dto) => AddAsync(dto);
        public Task<Pais> Modificar(Pais dto) => UpdateAsync(dto);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
