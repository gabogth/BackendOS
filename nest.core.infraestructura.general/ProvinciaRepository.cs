using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class ProvinciaRepository : CachedRepositoryBase<Provincia, ProvinciaCrearDto, int>, IProvinciaRepository
    {
        public ProvinciaRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<Provincia> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Provincia>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Provincia>> ObtenerActivos() => await GetAllAsync();
        public Task<Provincia> Agregar(ProvinciaCrearDto dto) => AddAsync(dto);
        public Task<Provincia> Modificar(int id, ProvinciaCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
