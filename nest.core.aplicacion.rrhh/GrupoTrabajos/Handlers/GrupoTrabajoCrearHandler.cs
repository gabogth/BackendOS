using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Handlers
{
    public class GrupoTrabajoCrearHandler : IRequestHandler<GrupoTrabajoCrearCommand, GrupoTrabajo>
    {
        private readonly IGrupoTrabajoRepository repository;
        private readonly IGrupoTrabajoPersonaRepository personaRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<GrupoTrabajoCrearHandler> logger;

        public GrupoTrabajoCrearHandler(
            IGrupoTrabajoRepository repository,
            IGrupoTrabajoPersonaRepository personaRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<GrupoTrabajoCrearHandler> logger)
        {
            this.repository = repository;
            this.personaRepository = personaRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<GrupoTrabajo> Handle(GrupoTrabajoCrearCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var grupoTrabajo = mapper.Map<GrupoTrabajo>(request);
                grupoTrabajo = await repository.Agregar(grupoTrabajo);

                if (request.Personas.Count > 0)
                {
                    var personas = request.Personas
                        .Select(p => new GrupoTrabajoPersona
                        {
                            Id = p.Id ?? 0,
                            EmpresaId = grupoTrabajo.EmpresaId,
                            GrupoTrabajoId = grupoTrabajo.Id,
                            PersonaId = p.PersonaId,
                            EsLider = p.EsLider
                        })
                        .ToArray();

                    await personaRepository.AgregarRange(personas);
                }

                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(grupoTrabajo.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                logger.LogError(ex, "Error al crear el grupo de trabajo {Nombre}", request.Nombre);
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
