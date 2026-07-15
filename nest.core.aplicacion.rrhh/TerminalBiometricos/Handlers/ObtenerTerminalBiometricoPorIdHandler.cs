using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Queries;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Handlers;

public class ObtenerTerminalBiometricoPorIdHandler : IRequestHandler<ObtenerTerminalBiometricoPorIdQuery, TerminalBiometrico>
{
    private readonly ITerminalBiometricoRepository repository;
    private readonly ILogger<ObtenerTerminalBiometricoPorIdHandler> logger;

    public ObtenerTerminalBiometricoPorIdHandler(ITerminalBiometricoRepository repository, ILogger<ObtenerTerminalBiometricoPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<TerminalBiometrico> Handle(ObtenerTerminalBiometricoPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el terminal biométrico {Id}", request.Id);
            throw;
        }
    }
}
