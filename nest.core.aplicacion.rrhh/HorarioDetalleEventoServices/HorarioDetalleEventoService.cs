using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventoServices
{
    public class HorarioDetalleEventoService
    {
        private readonly IHorarioDetalleEventoRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public HorarioDetalleEventoService(IHorarioDetalleEventoRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public Task<HorarioDetalleEvento?> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<HorarioDetalleEvento>> ObtenerPorHorarioDetalleId(long horarioDetalleId) => repository.ObtenerPorHorarioDetalleId(horarioDetalleId);
        public Task<List<HorarioDetalleEvento>> ObtenerTodos() => repository.ObtenerTodos();

        public async Task<HorarioDetalleEvento> Agregar(long horarioDetalleId, HorarioDetalleEventoCrearDto entry)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                HorarioDetalleEvento evento = await repository.Agregar(horarioDetalleId, entry);
                await unitOfWork.CommitAsync();
                return evento;
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public async Task<HorarioDetalleEvento> Modificar(long id, HorarioDetalleEventoCrearDto entry)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                HorarioDetalleEvento evento = await repository.Modificar(id, entry);
                await unitOfWork.CommitAsync();
                return evento;
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
