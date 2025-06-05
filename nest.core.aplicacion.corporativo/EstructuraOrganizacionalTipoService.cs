using nest.core.dominio.Corporativo;

namespace nest.core.aplicacion.corporativo;

public class EstructuraOrganizacionalTipoService
{
    private readonly IEstructuraOrganizacionalTipoRepository repository;
    public EstructuraOrganizacionalTipoService(IEstructuraOrganizacionalTipoRepository repository)
    {
        this.repository = repository;
    }

    public Task<EstructuraOrganizacionalTipo> ObtenerPorId(int id) => repository.ObtenerPorId(id);
    public Task<List<EstructuraOrganizacionalTipo>> ObtenerTodos() => repository.ObtenerTodos();
    public Task<List<EstructuraOrganizacionalTipo>> ObtenerActivos() => repository.ObtenerActivos();
    public Task<EstructuraOrganizacionalTipo> Agregar(EstructuraOrganizacionalTipoCrearDto entry) => repository.Agregar(entry);
    public Task<EstructuraOrganizacionalTipo> Modificar(int id, EstructuraOrganizacionalTipoCrearDto entry) => repository.Modificar(id, entry);
    public Task Eliminar(int id) => repository.Eliminar(id);
}
