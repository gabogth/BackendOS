using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicaServices
{
    public class UbicacionTecnicaService
    {
        private readonly IUbicacionTecnicaRepository repository;

        public UbicacionTecnicaService(IUbicacionTecnicaRepository repository)
        {
            this.repository = repository;
        }

        public Task<UbicacionTecnica> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<UbicacionTecnica>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<UbicacionTecnica>> ObtenerActivas() => repository.ObtenerActivas();
        public Task<UbicacionTecnica> Agregar(UbicacionTecnicaCrearDto entry) => repository.Agregar(entry);
        public Task<UbicacionTecnica> Modificar(long id, UbicacionTecnicaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
