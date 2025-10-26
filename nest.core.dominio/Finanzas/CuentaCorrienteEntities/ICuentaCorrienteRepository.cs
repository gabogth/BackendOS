namespace nest.core.dominio.Finanzas.CuentaCorrienteEntities
{
    public interface ICuentaCorrienteRepository
    {
        Task<CuentaCorriente> ObtenerPorId(int id);
        Task<List<CuentaCorriente>> ObtenerTodos();
        Task<List<CuentaCorriente>> ObtenerActivos();
        Task<CuentaCorriente> Agregar(CuentaCorriente entry);
        Task<CuentaCorriente> Modificar(CuentaCorriente entry);
        Task Eliminar(int id);
    }
}
