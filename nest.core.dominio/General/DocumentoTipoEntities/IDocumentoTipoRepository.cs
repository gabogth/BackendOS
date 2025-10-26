namespace nest.core.dominio.General.DocumentoTipoEntities
{
    public interface IDocumentoTipoRepository
    {
        Task<DocumentoTipo> ObtenerPorId(int id);
        Task<List<DocumentoTipo>> ObtenerTodos();
        Task<List<DocumentoTipo>> ObtenerActivos();
        Task<DocumentoTipo> Agregar(DocumentoTipo entry);
        Task<DocumentoTipo> Modificar(DocumentoTipo entry);
        Task Eliminar(int id);
    }
}
