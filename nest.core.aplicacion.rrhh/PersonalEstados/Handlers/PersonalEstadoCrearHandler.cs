using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalEstados.Commands;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Handlers;

public class PersonalEstadoCrearHandler : IRequestHandler<PersonalEstadoCrearCommand, PersonalEstado>
{
    private readonly IPersonalEstadoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<PersonalEstadoCrearHandler> logger;

    public PersonalEstadoCrearHandler(IPersonalEstadoRepository repository, IMapper mapper, ILogger<PersonalEstadoCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<PersonalEstado> Handle(PersonalEstadoCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<PersonalEstado>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear el estado de personal {Nombre}", request.Nombre);
            throw;
        }
    }
}
