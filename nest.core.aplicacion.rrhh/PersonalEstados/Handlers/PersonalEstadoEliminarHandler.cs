using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalEstados.Commands;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Handlers;

public class PersonalEstadoEliminarHandler : IRequestHandler<PersonalEstadoEliminarCommand, Unit>
{
    private readonly IPersonalEstadoRepository repository;
    private readonly ILogger<PersonalEstadoEliminarHandler> logger;

    public PersonalEstadoEliminarHandler(IPersonalEstadoRepository repository, ILogger<PersonalEstadoEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(PersonalEstadoEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el estado de personal {Id}", request.Id);
            throw;
        }
    }
}
