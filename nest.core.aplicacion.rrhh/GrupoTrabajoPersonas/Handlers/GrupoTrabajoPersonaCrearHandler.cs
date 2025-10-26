using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Handlers;

public class GrupoTrabajoPersonaCrearHandler : IRequestHandler<GrupoTrabajoPersonaCrearCommand, GrupoTrabajoPersona>
{
    private readonly IGrupoTrabajoPersonaRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GrupoTrabajoPersonaCrearHandler> logger;

    public GrupoTrabajoPersonaCrearHandler(IGrupoTrabajoPersonaRepository repository, IMapper mapper, ILogger<GrupoTrabajoPersonaCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<GrupoTrabajoPersona> Handle(GrupoTrabajoPersonaCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<GrupoTrabajoPersona>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al agregar la persona {PersonaId} al grupo {GrupoTrabajoId}", request.PersonaId, request.GrupoTrabajoId);
            throw;
        }
    }
}
