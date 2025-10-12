using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceraServices
{
    public class OrdenServicioCabeceraService
    {
        private readonly IOrdenServicioCabeceraRepository repository;

        public OrdenServicioCabeceraService(IOrdenServicioCabeceraRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenServicioCabecera> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenServicioCabecera>> ObtenerTodos() => repository.ObtenerTodos();

        public Task<OrdenServicioCabecera> Agregar(OrdenServicioCabeceraCrearDto dto) => repository.Agregar(dto);

        public Task<OrdenServicioCabecera> Modificar(long id, OrdenServicioCabeceraCrearDto dto) => repository.Modificar(id, dto);

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
