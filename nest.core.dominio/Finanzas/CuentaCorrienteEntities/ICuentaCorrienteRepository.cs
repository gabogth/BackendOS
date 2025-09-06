namespace nest.core.dominio.Finanzas.CuentaCorrienteEntities
{
    public interface ICuentaCorrienteRepository
    {
        Task<CuentaCorriente> ObtenerPorId(int id);
        Task<List<CuentaCorriente>> ObtenerTodos();
        Task<List<CuentaCorriente>> ObtenerActivos();
        Task<CuentaCorriente> Agregar(CuentaCorrienteCrearDto entidad);
        Task<CuentaCorriente> Modificar(int id, CuentaCorrienteCrearDto entidad);
        Task Eliminar(int id);
    }
}
