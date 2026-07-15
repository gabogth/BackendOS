using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Handlers;

public class TerminalBiometricoModificarHandler : IRequestHandler<TerminalBiometricoModificarCommand, TerminalBiometrico>
{
    private readonly ITerminalBiometricoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<TerminalBiometricoModificarHandler> logger;

    public TerminalBiometricoModificarHandler(ITerminalBiometricoRepository repository, IMapper mapper, ILogger<TerminalBiometricoModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<TerminalBiometrico> Handle(TerminalBiometricoModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<TerminalBiometrico>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el terminal biométrico {Id}", request.Id);
            throw;
        }
    }
}
