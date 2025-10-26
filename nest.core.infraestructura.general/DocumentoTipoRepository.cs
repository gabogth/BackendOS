using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class DocumentoTipoRepository : CachedRepositoryBase<DocumentoTipo, int>, IDocumentoTipoRepository
    {
        public DocumentoTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<DocumentoTipo> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<DocumentoTipo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<DocumentoTipo>> ObtenerActivos() => await GetAllAsync();
        public Task<DocumentoTipo> Agregar(DocumentoTipo entry) => AddAsync(entry);
        public Task<DocumentoTipo> Modificar(DocumentoTipo entry) => UpdateAsync(entry);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
