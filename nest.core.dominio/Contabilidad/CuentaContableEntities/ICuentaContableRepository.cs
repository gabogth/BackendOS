namespace nest.core.dominio.Contabilidad.CuentaContableEntities
{
    public interface ICuentaContableRepository
    {
        Task<CuentaContable> ObtenerPorId(long id);
        Task<List<CuentaContable>> ObtenerTodos();
        Task<List<CuentaContable>> ObtenerActivos();
        Task<CuentaContable> Agregar(CuentaContable entidad);
        Task<CuentaContable> Modificar(CuentaContable entidad);
        Task Eliminar(long id);
    }
}
