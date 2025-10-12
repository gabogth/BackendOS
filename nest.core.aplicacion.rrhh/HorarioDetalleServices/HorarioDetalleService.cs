using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.HorarioDetalleServices
{
    public class HorarioDetalleService
    {
        private readonly IHorarioDetalleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public HorarioDetalleService(IHorarioDetalleRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public Task<HorarioDetalle?> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<HorarioDetalle>> ObtenerPorCabeceraId(int horarioCabeceraId) => repository.ObtenerPorCabeceraId(horarioCabeceraId);
        public Task<List<HorarioDetalle>> ObtenerTodos() => repository.ObtenerTodos();

        public async Task<HorarioDetalle> Agregar(int horarioCabeceraId, HorarioDetalleCrearDto entry)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                HorarioDetalle detalle = await repository.Agregar(horarioCabeceraId, entry);
                await unitOfWork.CommitAsync();
                return detalle;
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

        public async Task<HorarioDetalle> Modificar(long id, HorarioDetalleCrearDto entry)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                HorarioDetalle detalle = await repository.Modificar(id, entry);
                await unitOfWork.CommitAsync();
                return detalle;
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
