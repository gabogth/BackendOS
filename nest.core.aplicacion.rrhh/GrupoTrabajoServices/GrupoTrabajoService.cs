using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoServices
{
    public class GrupoTrabajoService
    {
        private readonly IGrupoTrabajoRepository repository;
        private readonly IGrupoTrabajoPersonaRepository grupoTrabajoPersonaRepository;
        private readonly IUnitOfWork unitOfWork;

        public GrupoTrabajoService(IGrupoTrabajoRepository repository, IUnitOfWork unitOfWork, IGrupoTrabajoPersonaRepository grupoTrabajoPersonaRepository)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.grupoTrabajoPersonaRepository = grupoTrabajoPersonaRepository;
        }

        public Task<GrupoTrabajo> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<GrupoTrabajo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<GrupoTrabajo>> ObtenerActivos() => repository.ObtenerActivos();

        public async Task<GrupoTrabajo> Agregar(GrupoTrabajoDto entry)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var grupoTrabajo = await repository.Agregar(entry.Cabecera);
                entry.Personas.ForEach(p =>
                {
                    p.GrupoTrabajoId = grupoTrabajo.Id;
                    p.EmpresaId = grupoTrabajo.EmpresaId;
                });
                GrupoTrabajoPersona[] personasEntities = entry.Personas
                    .Select(p => new GrupoTrabajoPersona
                    {
                        Id = p.Id ?? 0,
                        EmpresaId = p.EmpresaId,
                        GrupoTrabajoId = p.GrupoTrabajoId,
                        PersonaId = p.PersonaId,
                        EsLider = p.EsLider
                    })
                    .ToArray();

                await this.grupoTrabajoPersonaRepository.AgregarRange(personasEntities);
                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(grupoTrabajo.Id);
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
                var grupoTrabajo = await repository.Modificar(id, entry.Cabecera);
                var grupoTrabajoFull = await repository.ObtenerPorId(grupoTrabajo.Id);
                entry.Personas.ForEach(p =>
                {
                    p.GrupoTrabajoId = grupoTrabajo.Id;
                    p.EmpresaId = grupoTrabajo.EmpresaId;
                });
                GrupoTrabajoPersona[] personasEntities = entry.Personas
                    .Select(p => new GrupoTrabajoPersona
                    {
                        Id = p.Id ?? 0,
                        EmpresaId = p.EmpresaId,
                        GrupoTrabajoId = p.GrupoTrabajoId,
                        PersonaId = p.PersonaId,
                        EsLider = p.EsLider
                    })
                    .ToArray();

                await this.grupoTrabajoPersonaRepository.FusionarRange(grupoTrabajoFull.GrupoTrabajoPersonas.ToArray(), personasEntities);
                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(grupoTrabajo.Id);
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
