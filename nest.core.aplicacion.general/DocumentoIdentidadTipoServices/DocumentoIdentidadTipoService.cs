using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipoServices
{
    public class DocumentoIdentidadTipoService
    {
        private readonly IDocumentoIdentidadTipoRepository repository;
        public DocumentoIdentidadTipoService(IDocumentoIdentidadTipoRepository repository)
        {
            this.repository = repository;
        }
        public Task<DocumentoIdentidadTipo> ObtenerPorId(byte id) => repository.ObtenerPorId(id);
        public Task<List<DocumentoIdentidadTipo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<DocumentoIdentidadTipo>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<DocumentoIdentidadTipo> Agregar(DocumentoIdentidadTipoCrearDto entry) => repository.Agregar(entry);
        public Task<DocumentoIdentidadTipo> Modificar(byte id, DocumentoIdentidadTipoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(byte id) => repository.Eliminar(id);
    }
}
