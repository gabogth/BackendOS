namespace nest.core.dominio.General.DepartamentoEntites
{
    public interface IDepartamentoRepository
    {
        Task<Departamento> ObtenerPorId(int id);
        Task<List<Departamento>> ObtenerTodos();
        Task<Departamento> Agregar(Departamento entry);
        Task<Departamento> Modificar(Departamento entry);
        Task Eliminar(int id);
    }
}
