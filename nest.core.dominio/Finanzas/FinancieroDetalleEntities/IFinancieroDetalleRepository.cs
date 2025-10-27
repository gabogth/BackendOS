namespace nest.core.dominio.Finanzas.FinancieroDetalleEntities
{
    public interface IFinancieroDetalleRepository
    {
        Task<FinancieroDetalle> ObtenerPorId(long id);
        Task<List<FinancieroDetalle>> ObtenerTodos();
        Task<List<FinancieroDetalle>> ObtenerPorCabecera(long cabeceraId);
        Task<FinancieroDetalle> Agregar(FinancieroDetalle entidad);
        Task<FinancieroDetalle> Modificar(FinancieroDetalle entidad);
        Task Eliminar(long id);
    }
}
