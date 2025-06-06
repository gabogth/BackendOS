namespace nest.core.dominio.General.DocumentoTipoEntities
{
    public interface IDocumentoTipoRepository
    {
        Task<DocumentoTipo> ObtenerPorId(int id);
        Task<List<DocumentoTipo>> ObtenerTodos();
        Task<List<DocumentoTipo>> ObtenerActivos();
        Task<DocumentoTipo> Agregar(DocumentoTipoCrearDto entry);
        Task<DocumentoTipo> Modificar(int id, DocumentoTipoCrearDto entry);
        Task Eliminar(int id);
    }
}
