namespace nest.core.dominio.Corporativo;

public interface IEstructuraOrganizacionalTipoRepository
{
    Task<EstructuraOrganizacionalTipo> ObtenerPorId(int id);
    Task<List<EstructuraOrganizacionalTipo>> ObtenerTodos();
    Task<List<EstructuraOrganizacionalTipo>> ObtenerActivos();
    Task<EstructuraOrganizacionalTipo> Agregar(EstructuraOrganizacionalTipoCrearDto entidad);
    Task<EstructuraOrganizacionalTipo> Modificar(int id, EstructuraOrganizacionalTipoCrearDto entidad);
    Task Eliminar(int id);
}
