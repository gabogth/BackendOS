using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general
{
    public class LicenciaConducirService
    {
        private readonly ILicenciaConducirRepository repository;
        public LicenciaConducirService(ILicenciaConducirRepository repository)
        {
            this.repository = repository;
        }
        public Task<LicenciaConducir> ObtenerPorId(byte id) => repository.ObtenerPorId(id);
        public Task<List<LicenciaConducir>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<LicenciaConducir>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<LicenciaConducir> Agregar(LicenciaConducirCrearDto entry) => repository.Agregar(entry);
        public Task<LicenciaConducir> Modificar(byte id, LicenciaConducirCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(byte id) => repository.Eliminar(id);
    }
}
