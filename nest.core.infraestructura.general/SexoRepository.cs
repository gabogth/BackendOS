using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.SexoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class SexoRepository : CachedRepositoryBase<Sexo, SexoCrearDto, byte>, ISexoRepository
    {
        public SexoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<Sexo> ObtenerPorId(byte id) => await GetByIdAsync(id);
        public async Task<List<Sexo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Sexo>> ObtenerActivos() => await GetAllAsync();
        public Task<Sexo> Agregar(SexoCrearDto dto) => AddAsync(dto);
        public Task<Sexo> Modificar(byte id, SexoCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(byte id) => DeleteAsync(id);
    }
}
