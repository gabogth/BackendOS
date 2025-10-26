using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.dominio.Finanzas.FinancieroCabeceraEntities
{
    public interface IFinancieroRepository
    {
        Task<FinancieroCabecera> ObtenerPorId(long id);
        Task<List<FinancieroCabecera>> ObtenerTodos();
        Task<FinancieroCabecera> Agregar(FinancieroCabecera entidad, bool transaccional);
        Task<FinancieroCabecera> Modificar(FinancieroCabecera entidad, bool transaccional);
        Task<FinancieroDetalle> AgregarDetalle(FinancieroDetalle entry);
        Task<FinancieroDetalle> ModificarDetalle(FinancieroDetalle entry);
        Task Eliminar(long id);
        Task EliminarDetalle(long id);
    }
}
