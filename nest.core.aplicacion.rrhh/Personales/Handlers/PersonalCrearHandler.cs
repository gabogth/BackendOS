using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Personales.Commands;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Handlers;

public class PersonalCrearHandler : IRequestHandler<PersonalCrearCommand, Personal>
{
    private readonly IPersonalRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<PersonalCrearHandler> logger;

    public PersonalCrearHandler(IPersonalRepository repository, IMapper mapper, ILogger<PersonalCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Personal> Handle(PersonalCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<Personal>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al registrar el personal {Id}", request.Id);
            throw;
        }
    }
}
