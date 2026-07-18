using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Queries;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Handlers;

public class ObtenerTerminalBiometricosPorFiltroActivosHandler : IRequestHandler<ObtenerTerminalBiometricosPorFiltroActivosQuery, LoadResult>
{
    private readonly ITerminalBiometricoRepository repository;
    private readonly ILogger<ObtenerTerminalBiometricosPorFiltroActivosHandler> logger;

    public ObtenerTerminalBiometricosPorFiltroActivosHandler(ITerminalBiometricoRepository repository, ILogger<ObtenerTerminalBiometricosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerTerminalBiometricosPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los terminales biométricos activos por filtro datasource");
            throw;
        }
    }
}
