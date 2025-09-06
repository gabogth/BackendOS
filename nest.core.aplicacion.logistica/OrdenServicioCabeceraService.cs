using nest.core.dominio.Logistica.OrdenServicio;

namespace nest.core.aplicacion.logistica
{
    public class OrdenServicioCabeceraService
    {
        private readonly IOrdenServicioCabeceraRepository repository;
        public OrdenServicioCabeceraService(IOrdenServicioCabeceraRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenServicioCabecera> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<OrdenServicioCabecera>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<OrdenServicioCabecera> Agregar(OrdenServicioCabeceraCrearDto entry) => repository.Agregar(entry);
        public Task<OrdenServicioCabecera> Modificar(int id, OrdenServicioCabeceraCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
