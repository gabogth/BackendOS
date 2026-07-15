using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Queries;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Handlers;

public class ObtenerTerminalBiometricosPorFiltroDataSourceHandler : IRequestHandler<ObtenerTerminalBiometricosPorFiltroDataSourceQuery, LoadResult>
{
    private readonly ITerminalBiometricoRepository repository;
    private readonly ILogger<ObtenerTerminalBiometricosPorFiltroDataSourceHandler> logger;

    public ObtenerTerminalBiometricosPorFiltroDataSourceHandler(ITerminalBiometricoRepository repository, ILogger<ObtenerTerminalBiometricosPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerTerminalBiometricosPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los terminales biométricos por filtro datasource");
            throw;
        }
    }
}
