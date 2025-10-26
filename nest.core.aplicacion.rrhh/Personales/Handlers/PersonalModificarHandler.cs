using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Personales.Commands;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Handlers;

public class PersonalModificarHandler : IRequestHandler<PersonalModificarCommand, Personal>
{
    private readonly IPersonalRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<PersonalModificarHandler> logger;

    public PersonalModificarHandler(IPersonalRepository repository, IMapper mapper, ILogger<PersonalModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Personal> Handle(PersonalModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<Personal>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el personal {Id}", request.Id);
            throw;
        }
    }
}
