namespace nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities
{
    public interface IEstructuraOrganizacionalTipoRepository
    {
        Task<EstructuraOrganizacionalTipo> ObtenerPorId(int id);
        Task<List<EstructuraOrganizacionalTipo>> ObtenerTodos();
        Task<List<EstructuraOrganizacionalTipo>> ObtenerActivos();
        Task<EstructuraOrganizacionalTipo> Agregar(EstructuraOrganizacionalTipo entidad);
        Task<EstructuraOrganizacionalTipo> Modificar(EstructuraOrganizacionalTipo entidad);
        Task Eliminar(int id);
    }
}
