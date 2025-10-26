namespace nest.core.dominio.Contabilidad.CuentaContableTipoEntities
{
    public interface ICuentaContableTipoRepository
    {
        Task<CuentaContableTipo> ObtenerPorId(int id);
        Task<List<CuentaContableTipo>> ObtenerTodos();
        Task<List<CuentaContableTipo>> ObtenerActivos();
        Task<CuentaContableTipo> Agregar(CuentaContableTipo entidad);
        Task<CuentaContableTipo> Modificar(CuentaContableTipo entidad);
        Task Eliminar(int id);
    }
}
