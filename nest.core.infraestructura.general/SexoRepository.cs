using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.SexoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class SexoRepository : CachedRepositoryBase<Sexo, byte>, ISexoRepository
    {
        public SexoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<Sexo> ObtenerPorId(byte id) => await GetByIdAsync(id);
        public async Task<List<Sexo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Sexo>> ObtenerActivos() => await GetAllAsync();
        public Task<Sexo> Agregar(Sexo entry) => AddAsync(entry);
        public Task<Sexo> Modificar(Sexo entry) => UpdateAsync(entry);
        public Task Eliminar(byte id) => DeleteAsync(id);
    }
}
