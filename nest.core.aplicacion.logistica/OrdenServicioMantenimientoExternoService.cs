using nest.core.dominio.Logistica.OrdenServicio;

namespace nest.core.aplicacion.logistica
{
    public class OrdenServicioMantenimientoExternoService
    {
        private readonly IOrdenServicioMantenimientoExternoRepository repository;
        public OrdenServicioMantenimientoExternoService(IOrdenServicioMantenimientoExternoRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenServicioCabecera> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<OrdenServicioCabecera>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<OrdenServicioMantenimientoExterno> Agregar(OrdenServicioMantenimientoExternoCrearDto entry) => repository.Agregar(entry);
        public Task<OrdenServicioCabecera> Modificar(int id, OrdenServicioMantenimientoExternoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
