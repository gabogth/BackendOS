namespace nest.core.dominio.General.AdjuntoTipoEntities
{
    public interface IAdjuntoTipoRepository
    {
        Task<AdjuntoTipo> ObtenerPorId(AdjuntoTipoEnum id);
        Task<List<AdjuntoTipo>> ObtenerTodos();
        Task<List<AdjuntoTipo>> ObtenerActivos();
        Task<AdjuntoTipo> Agregar(AdjuntoTipo entry);
        Task<AdjuntoTipo> Modificar(AdjuntoTipo entry);
        Task Eliminar(AdjuntoTipoEnum id);
    }
}
