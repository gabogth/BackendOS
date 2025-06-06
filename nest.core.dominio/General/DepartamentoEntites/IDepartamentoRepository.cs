namespace nest.core.dominio.General.DepartamentoEntites
{
    public interface IDepartamentoRepository
    {
        Task<Departamento> ObtenerPorId(int id);
        Task<List<Departamento>> ObtenerTodos();
        Task<List<Departamento>> ObtenerActivos();
        Task<Departamento> Agregar(DepartamentoCrearDto entry);
        Task<Departamento> Modificar(int id, DepartamentoCrearDto entry);
        Task Eliminar(int id);
    }
}
