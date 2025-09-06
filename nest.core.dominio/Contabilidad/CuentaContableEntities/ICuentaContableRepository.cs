namespace nest.core.dominio.Contabilidad.CuentaContableEntities
{
    public interface ICuentaContableRepository
    {
        Task<CuentaContable> ObtenerPorId(int id);
        Task<List<CuentaContable>> ObtenerTodos();
        Task<List<CuentaContable>> ObtenerActivos();
        Task<CuentaContable> Agregar(CuentaContableCrearDto entidad);
        Task<CuentaContable> Modificar(int id, CuentaContableCrearDto entidad);
        Task Eliminar(int id);
    }
}
