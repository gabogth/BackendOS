using System.Collections.Generic;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoServices
{
    public class GrupoTrabajoService
    {
        private readonly IGrupoTrabajoRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public GrupoTrabajoService(IGrupoTrabajoRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public Task<GrupoTrabajo> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<GrupoTrabajo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<GrupoTrabajo>> ObtenerActivos() => repository.ObtenerActivos();

        public async Task<GrupoTrabajo> Agregar(GrupoTrabajoDto entry)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var grupoTrabajo = await repository.Agregar(entry);
                await unitOfWork.CommitAsync();
                return grupoTrabajo;
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

        public async Task<GrupoTrabajo> Modificar(long id, GrupoTrabajoDto entry)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var grupoTrabajo = await repository.Modificar(id, entry);
                await unitOfWork.CommitAsync();
                return grupoTrabajo;
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
