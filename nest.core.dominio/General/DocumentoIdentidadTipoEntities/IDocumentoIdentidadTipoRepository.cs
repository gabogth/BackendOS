namespace nest.core.dominio.General.DocumentoIdentidadTipoEntities
{
    public interface IDocumentoIdentidadTipoRepository
    {
        Task<DocumentoIdentidadTipo> ObtenerPorId(byte id);
        Task<List<DocumentoIdentidadTipo>> ObtenerTodos();
        Task<List<DocumentoIdentidadTipo>> ObtenerActivos();
        Task<DocumentoIdentidadTipo> Agregar(DocumentoIdentidadTipoCrearDto entry);
        Task<DocumentoIdentidadTipo> Modificar(byte id, DocumentoIdentidadTipoCrearDto entry);
        Task Eliminar(byte id);
    }
}
