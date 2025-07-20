namespace nest.core.dominio.Contabilidad.CuentaContableTipoEntities
{
    public interface ICuentaContableTipoRepository
    {
        Task<CuentaContableTipo> ObtenerPorId(int id);
        Task<List<CuentaContableTipo>> ObtenerTodos();
        Task<List<CuentaContableTipo>> ObtenerActivos();
        Task<CuentaContableTipo> Agregar(CuentaContableTipoCrearDto entidad);
        Task<CuentaContableTipo> Modificar(int id, CuentaContableTipoCrearDto entidad);
        Task Eliminar(int id);
    }
}
