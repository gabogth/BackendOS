namespace nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities
{
    public interface IEstructuraOrganizacionalRepository
    {
        Task<EstructuraOrganizacional> ObtenerPorId(int id);
        Task<List<EstructuraOrganizacional>> ObtenerTodos();
        Task<List<EstructuraOrganizacional>> ObtenerActivos();
        Task<EstructuraOrganizacional> Agregar(EstructuraOrganizacionalCrearDto entidad);
        Task<EstructuraOrganizacional> Modificar(int id, EstructuraOrganizacionalCrearDto entidad);
        Task Eliminar(int id);
    }
}
