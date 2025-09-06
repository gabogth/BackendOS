using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipoServices
{
    public class OrdenServicioTipoService
    {
        private readonly IOrdenServicioTipoRepository repository;
        public OrdenServicioTipoService(IOrdenServicioTipoRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenServicioTipo> ObtenerPorId(short id) => repository.ObtenerPorId(id);
        public Task<List<OrdenServicioTipo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<OrdenServicioTipo>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<OrdenServicioTipo> Agregar(OrdenServicioTipoCrearDto entry) => repository.Agregar(entry);
        public Task<OrdenServicioTipo> Modificar(short id, OrdenServicioTipoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(short id) => repository.Eliminar(id);
    }
}
