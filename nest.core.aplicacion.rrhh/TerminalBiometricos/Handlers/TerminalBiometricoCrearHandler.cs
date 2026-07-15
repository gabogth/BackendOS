using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Handlers;

public class TerminalBiometricoCrearHandler : IRequestHandler<TerminalBiometricoCrearCommand, TerminalBiometrico>
{
    private readonly ITerminalBiometricoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<TerminalBiometricoCrearHandler> logger;

    public TerminalBiometricoCrearHandler(ITerminalBiometricoRepository repository, IMapper mapper, ILogger<TerminalBiometricoCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<TerminalBiometrico> Handle(TerminalBiometricoCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<TerminalBiometrico>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear el terminal biométrico {Nombre}", request.Nombre);
            throw;
        }
    }
}
