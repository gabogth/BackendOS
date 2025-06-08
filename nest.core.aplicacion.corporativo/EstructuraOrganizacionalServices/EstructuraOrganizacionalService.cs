using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalServices
{
    public class EstructuraOrganizacionalService
    {
        private readonly IEstructuraOrganizacionalRepository repository;

        public EstructuraOrganizacionalService(IEstructuraOrganizacionalRepository repository)
        {
            this.repository = repository;
        }

        public Task<EstructuraOrganizacional> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<EstructuraOrganizacional>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<EstructuraOrganizacional>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<EstructuraOrganizacional> Agregar(EstructuraOrganizacionalCrearDto entry) => repository.Agregar(entry);
        public Task<EstructuraOrganizacional> Modificar(int id, EstructuraOrganizacionalCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
