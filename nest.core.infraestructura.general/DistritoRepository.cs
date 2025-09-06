using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.DistritoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class DistritoRepository : CachedRepositoryBase<Distrito, DistritoCrearDto, int>, IDistritoRepository
    {
        public DistritoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<Distrito> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Distrito>> ObtenerTodos() => await GetAllAsync();
        public async Task<Distrito> Agregar(DistritoCrearDto dto) => await AddAsync(dto);
        public async Task<Distrito> Modificar(int id, DistritoCrearDto dto) => await UpdateAsync(id, dto);
        public async Task Eliminar(int id) => await DeleteAsync(id);
    }
}
