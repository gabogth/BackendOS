namespace nest.core.dominio.Finanzas.PuntoFinancieroEntities
{
    public interface IPuntoFinancieroRepository
    {
        Task<PuntoFinanciero> ObtenerPorId(int id);
        Task<List<PuntoFinanciero>> ObtenerTodos();
        Task<List<PuntoFinanciero>> ObtenerActivos();
        Task<PuntoFinanciero> Agregar(PuntoFinancieroCrearDto entidad);
        Task<PuntoFinanciero> Modificar(int id, PuntoFinancieroCrearDto entidad);
        Task Eliminar(int id);
    }
}
