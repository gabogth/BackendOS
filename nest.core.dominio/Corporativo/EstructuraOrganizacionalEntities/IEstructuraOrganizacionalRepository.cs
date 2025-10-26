namespace nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities
{
    public interface IEstructuraOrganizacionalRepository
    {
        Task<EstructuraOrganizacional> ObtenerPorId(int id);
        Task<List<EstructuraOrganizacional>> ObtenerTodos();
        Task<List<EstructuraOrganizacional>> ObtenerActivos();
        Task<EstructuraOrganizacional> Agregar(EstructuraOrganizacional entidad);
        Task<EstructuraOrganizacional> Modificar(EstructuraOrganizacional entidad);
        Task Eliminar(int id);
    }
}
