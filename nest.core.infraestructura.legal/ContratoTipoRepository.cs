using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.Legal.ContratoTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.legal
{
    public class ContratoTipoRepository : CachedRepositoryBase<ContratoTipo, byte>, IContratoTipoRepository
    {
        public ContratoTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        public async Task<ContratoTipo> ObtenerPorId(byte id) => await GetByIdAsync(id);
        public async Task<List<ContratoTipo>> ObtenerTodos() => await GetAllAsync();
        public Task<ContratoTipo> Agregar(ContratoTipo entry) => AddAsync(entry);
        public Task<ContratoTipo> Modificar(ContratoTipo entry) => UpdateAsync(entry);
        public Task Eliminar(byte id) => DeleteAsync(id);
    }
}
