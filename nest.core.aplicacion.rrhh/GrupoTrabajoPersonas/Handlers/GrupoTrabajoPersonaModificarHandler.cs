using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Handlers;

public class GrupoTrabajoPersonaModificarHandler : IRequestHandler<GrupoTrabajoPersonaModificarCommand, GrupoTrabajoPersona>
{
    private readonly IGrupoTrabajoPersonaRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GrupoTrabajoPersonaModificarHandler> logger;

    public GrupoTrabajoPersonaModificarHandler(IGrupoTrabajoPersonaRepository repository, IMapper mapper, ILogger<GrupoTrabajoPersonaModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<GrupoTrabajoPersona> Handle(GrupoTrabajoPersonaModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<GrupoTrabajoPersona>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar la persona {Id} del grupo {GrupoTrabajoId}", request.Id, request.GrupoTrabajoId);
            throw;
        }
    }
}
