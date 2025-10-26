using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class DocumentoIdentidadTipoRepository : CachedRepositoryBase<DocumentoIdentidadTipo, byte>, IDocumentoIdentidadTipoRepository
    {
        public DocumentoIdentidadTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<DocumentoIdentidadTipo> ObtenerPorId(byte id) => await GetByIdAsync(id);
        public async Task<List<DocumentoIdentidadTipo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<DocumentoIdentidadTipo>> ObtenerActivos() => await GetAllAsync();
        public Task<DocumentoIdentidadTipo> Agregar(DocumentoIdentidadTipo entry) => AddAsync(entry);
        public Task<DocumentoIdentidadTipo> Modificar(DocumentoIdentidadTipo entry) => UpdateAsync(entry);
        public Task Eliminar(byte id) => DeleteAsync(id);
    }
}
