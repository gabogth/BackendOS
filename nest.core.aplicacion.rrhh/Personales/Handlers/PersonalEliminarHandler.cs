using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Personales.Commands;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Handlers;

public class PersonalEliminarHandler : IRequestHandler<PersonalEliminarCommand, Unit>
{
    private readonly IPersonalRepository repository;
    private readonly ILogger<PersonalEliminarHandler> logger;

    public PersonalEliminarHandler(IPersonalRepository repository, ILogger<PersonalEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(PersonalEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el personal {Id}", request.Id);
            throw;
        }
    }
}
