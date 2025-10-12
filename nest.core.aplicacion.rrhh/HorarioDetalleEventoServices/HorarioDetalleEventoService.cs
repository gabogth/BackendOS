using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventoServices
{
    public class HorarioDetalleEventoService
    {
        private readonly IHorarioDetalleEventoRepository repository;

        public HorarioDetalleEventoService(IHorarioDetalleEventoRepository repository)
        {
            this.repository = repository;
        }

        public Task<HorarioDetalleEvento?> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<HorarioDetalleEvento>> ObtenerTodos() => repository.ObtenerTodos();
        public async Task<HorarioDetalleEvento> Agregar(HorarioDetalleEventoCrearDto entry) => await repository.Agregar(entry);
        public async Task<HorarioDetalleEvento> Modificar(long id, HorarioDetalleEventoCrearDto entry) => await repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
