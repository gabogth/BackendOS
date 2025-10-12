using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternoServices
{
    public class OrdenServicioMantenimientoExternoService
    {
        private readonly IOrdenServicioMantenimientoExternoRepository repository;

        public OrdenServicioMantenimientoExternoService(IOrdenServicioMantenimientoExternoRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenServicioMantenimientoExterno> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenServicioMantenimientoExterno>> ObtenerTodos() => repository.ObtenerTodos();

        public Task<OrdenServicioMantenimientoExterno> Agregar(OrdenServicioMantenimientoExternoCrearDto dto) => repository.Agregar(dto);

        public Task<OrdenServicioMantenimientoExterno> Modificar(long id, OrdenServicioMantenimientoExternoCrearDto dto) => repository.Modificar(id, dto);

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
