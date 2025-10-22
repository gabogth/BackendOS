namespace nest.core.dominio.General.AdjuntoProviderEntities
{
    public interface IAdjuntoConfigProviderRepository
    {
        Task<AdjuntoConfigProvider> ObtenerPorId(AdjuntoConfigProviderModuloEnum id);
        Task<List<AdjuntoConfigProvider>> ObtenerTodos();
        Task<List<AdjuntoConfigProvider>> ObtenerActivos();
        Task<AdjuntoConfigProvider> Agregar(AdjuntoConfigProviderCrearDto entry);
        Task<AdjuntoConfigProvider> Modificar(AdjuntoConfigProviderModuloEnum id, AdjuntoConfigProviderCrearDto entry);
        Task Eliminar(AdjuntoConfigProviderModuloEnum id);
    }
}
