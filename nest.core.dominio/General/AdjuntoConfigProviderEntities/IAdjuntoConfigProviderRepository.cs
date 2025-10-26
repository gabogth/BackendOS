namespace nest.core.dominio.General.AdjuntoProviderEntities
{
    public interface IAdjuntoConfigProviderRepository
    {
        Task<AdjuntoConfigProvider> ObtenerPorId(AdjuntoConfigProviderModuloEnum id);
        Task<List<AdjuntoConfigProvider>> ObtenerTodos();
        Task<List<AdjuntoConfigProvider>> ObtenerActivos();
        Task<AdjuntoConfigProvider> Agregar(AdjuntoConfigProvider entry);
        Task<AdjuntoConfigProvider> Modificar(AdjuntoConfigProvider entry);
        Task Eliminar(AdjuntoConfigProviderModuloEnum id);
    }
}
