using nest.core.dominio.Corporativo.Empresa;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.HorarioServices
{
    public class HorarioService
    {
        private readonly IHorarioRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public HorarioService(IHorarioRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public Task<HorarioCabecera> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<HorarioCabecera>> ObtenerTodos() => repository.ObtenerTodos();
        public async Task<HorarioCabecera> Agregar(HorarioDto entry)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                HorarioCabecera horarioCabecera = await repository.Agregar(entry);
                await this.unitOfWork.CommitAsync();
                return horarioCabecera;
            }
            catch (Exception)
            {
                await this.unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await this.unitOfWork.DisposeAsync();
            }
        }

        public async Task<HorarioCabecera> Modificar(int id, HorarioDto entry)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                HorarioCabecera horarioCabecera = await repository.Modificar(id, entry);
                await this.unitOfWork.CommitAsync();
                return horarioCabecera;
            }
            catch (Exception)
            {
                await this.unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await this.unitOfWork.DisposeAsync();
            }
        }
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
