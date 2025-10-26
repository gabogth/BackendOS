using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalEstados.Commands;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Handlers;

public class PersonalEstadoModificarHandler : IRequestHandler<PersonalEstadoModificarCommand, PersonalEstado>
{
    private readonly IPersonalEstadoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<PersonalEstadoModificarHandler> logger;

    public PersonalEstadoModificarHandler(IPersonalEstadoRepository repository, IMapper mapper, ILogger<PersonalEstadoModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<PersonalEstado> Handle(PersonalEstadoModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<PersonalEstado>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el estado de personal {Id}", request.Id);
            throw;
        }
    }
}
