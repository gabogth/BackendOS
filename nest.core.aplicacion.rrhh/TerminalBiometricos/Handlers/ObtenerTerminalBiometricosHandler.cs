using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Queries;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Handlers;

public class ObtenerTerminalBiometricosHandler : IRequestHandler<ObtenerTerminalBiometricosQuery, List<TerminalBiometrico>>
{
    private readonly ITerminalBiometricoRepository repository;
    private readonly ILogger<ObtenerTerminalBiometricosHandler> logger;

    public ObtenerTerminalBiometricosHandler(ITerminalBiometricoRepository repository, ILogger<ObtenerTerminalBiometricosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<TerminalBiometrico>> Handle(ObtenerTerminalBiometricosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los terminales biométricos");
            throw;
        }
    }
}
