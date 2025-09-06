using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class DocumentoTipoRepository : CachedRepositoryBase<DocumentoTipo, DocumentoTipoCrearDto, int>, IDocumentoTipoRepository
    {
        public DocumentoTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<DocumentoTipo> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<DocumentoTipo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<DocumentoTipo>> ObtenerActivos() => await GetAllAsync();
        public Task<DocumentoTipo> Agregar(DocumentoTipoCrearDto dto) => AddAsync(dto);
        public Task<DocumentoTipo> Modificar(int id, DocumentoTipoCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
