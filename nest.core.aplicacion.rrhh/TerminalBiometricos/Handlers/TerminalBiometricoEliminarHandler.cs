using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Handlers;

public class TerminalBiometricoEliminarHandler : IRequestHandler<TerminalBiometricoEliminarCommand, Unit>
{
    private readonly ITerminalBiometricoRepository repository;
    private readonly ILogger<TerminalBiometricoEliminarHandler> logger;

    public TerminalBiometricoEliminarHandler(ITerminalBiometricoRepository repository, ILogger<TerminalBiometricoEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(TerminalBiometricoEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el terminal biométrico {Id}", request.Id);
            throw;
        }
    }
}
