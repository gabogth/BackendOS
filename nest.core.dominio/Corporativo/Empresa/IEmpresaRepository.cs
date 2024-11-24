namespace nest.core.dominio.Corporativo.Empresa
{
    public interface IEmpresaRepository
    {
        List<Empresa> ObtenerTodos();
        List<Empresa> ObtenerActivos();
        Empresa ObtenerPorId(byte id);
    }
}


