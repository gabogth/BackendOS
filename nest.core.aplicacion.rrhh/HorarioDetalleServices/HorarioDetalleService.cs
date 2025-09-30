using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleServices
{
    public class HorarioDetalleService
    {
        private readonly IHorarioDetalleRepository repository;

        public HorarioDetalleService(IHorarioDetalleRepository repository)
        {
            this.repository = repository;
        }

        public Task<HorarioDetalle?> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<HorarioDetalle>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<HorarioDetalle>> ObtenerPorCabeceraId(int horarioCabeceraId) => repository.ObtenerPorCabeceraId(horarioCabeceraId);
        public Task<HorarioDetalle> Agregar(int horarioCabeceraId, HorarioDetalleCrearDto entry) => repository.Agregar(horarioCabeceraId, entry);
        public Task<HorarioDetalle> Modificar(long id, HorarioDetalleCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
