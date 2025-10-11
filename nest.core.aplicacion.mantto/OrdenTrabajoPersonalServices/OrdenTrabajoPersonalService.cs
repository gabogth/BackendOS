using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonalServices
{
    public class OrdenTrabajoPersonalService
    {
        private readonly IOrdenTrabajoPersonalRepository repository;

        public OrdenTrabajoPersonalService(IOrdenTrabajoPersonalRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenTrabajoPersonal> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenTrabajoPersonal>> ObtenerPorCabecera(long ordenTrabajoCabeceraId) => repository.ObtenerPorCabecera(ordenTrabajoCabeceraId);

        public Task<OrdenTrabajoPersonal> Agregar(OrdenTrabajoPersonalCrearDto entry) => repository.Agregar(entry);

        public Task<OrdenTrabajoPersonal> Modificar(long id, OrdenTrabajoPersonalCrearDto entry) => repository.Modificar(id, entry);

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
