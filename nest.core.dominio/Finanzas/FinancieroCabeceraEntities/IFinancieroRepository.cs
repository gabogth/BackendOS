using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.dominio.Finanzas.FinancieroCabeceraEntities
{
    public interface IFinancieroRepository
    {
        Task<FinancieroCabecera> ObtenerPorId(long id);
        Task<List<FinancieroCabecera>> ObtenerTodos();
        Task<FinancieroCabecera> Agregar(FinancieroDto entidad, bool transaccional);
        Task<FinancieroDetalle> AgregarDetalle(long financieroCabeceraId, FinancieroDetalleCrearDto entry);
        Task<FinancieroCabecera> Modificar(long id, FinancieroDto entidad, bool transaccional);
        Task<FinancieroDetalle> ModificarDetalle(long id, FinancieroDetalleCrearDto entry);
        Task Eliminar(long id);
        Task EliminarDetalle(long id);
    }
}
