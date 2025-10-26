namespace nest.core.dominio.General.DocumentoIdentidadTipoEntities
{
    public interface IDocumentoIdentidadTipoRepository
    {
        Task<DocumentoIdentidadTipo> ObtenerPorId(byte id);
        Task<List<DocumentoIdentidadTipo>> ObtenerTodos();
        Task<List<DocumentoIdentidadTipo>> ObtenerActivos();
        Task<DocumentoIdentidadTipo> Agregar(DocumentoIdentidadTipo entry);
        Task<DocumentoIdentidadTipo> Modificar(DocumentoIdentidadTipo entry);
        Task Eliminar(byte id);
    }
}
