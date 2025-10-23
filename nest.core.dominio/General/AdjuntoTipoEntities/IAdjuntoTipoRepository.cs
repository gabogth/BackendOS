namespace nest.core.dominio.General.AdjuntoTipoEntities
{
    public interface IAdjuntoTipoRepository
    {
        Task<AdjuntoTipo> ObtenerPorId(AdjuntoTipoEnum id);
        Task<List<AdjuntoTipo>> ObtenerTodos();
        Task<List<AdjuntoTipo>> ObtenerActivos();
        Task<AdjuntoTipo> Agregar(AdjuntoTipoCrearDto entry);
        Task<AdjuntoTipo> Modificar(AdjuntoTipoEnum id, AdjuntoTipoCrearDto entry);
        Task Eliminar(AdjuntoTipoEnum id);
    }
}
