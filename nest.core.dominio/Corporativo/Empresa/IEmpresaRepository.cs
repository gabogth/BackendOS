namespace nest.core.dominio.Corporativo.Empresa
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> ObtenerTodos();
        Task<List<Empresa>> ObtenerActivos();
        Task<Empresa?> ObtenerPorId(int id);
        Task<Empresa> Agregar(EmpresaCrearDto entry);
        Task<Empresa> Modificar(int id, EmpresaCrearDto entry);
        Task Eliminar(int id);
    }
}

