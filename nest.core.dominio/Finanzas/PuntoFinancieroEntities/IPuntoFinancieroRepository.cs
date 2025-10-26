namespace nest.core.dominio.Finanzas.PuntoFinancieroEntities
{
    public interface IPuntoFinancieroRepository
    {
        Task<PuntoFinanciero> ObtenerPorId(int id);
        Task<List<PuntoFinanciero>> ObtenerTodos();
        Task<List<PuntoFinanciero>> ObtenerActivos();
        Task<PuntoFinanciero> Agregar(PuntoFinanciero entidad);
        Task<PuntoFinanciero> Modificar(PuntoFinanciero entidad);
        Task Eliminar(int id);
    }
}
