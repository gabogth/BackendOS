using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.DocumentoTipoServices
{
    public class DocumentoTipoService
    {
        private readonly IDocumentoTipoRepository repository;
        public DocumentoTipoService(IDocumentoTipoRepository repository)
        {
            this.repository = repository;
        }
        public Task<DocumentoTipo> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<DocumentoTipo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<DocumentoTipo>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<DocumentoTipo> Agregar(DocumentoTipoCrearDto entry) => repository.Agregar(entry);
        public Task<DocumentoTipo> Modificar(int id, DocumentoTipoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
