using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Personales.Queries;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Handlers;

public class ObtenerPersonalPorDocumentoIdentidadHandler : IRequestHandler<ObtenerPersonalesPorDocumentoIdentidadQuery, Personal>
{
    private readonly IPersonalRepository repository;
    private readonly ILogger<ObtenerPersonalPorDocumentoIdentidadHandler> logger;

    public ObtenerPersonalPorDocumentoIdentidadHandler(IPersonalRepository repository, ILogger<ObtenerPersonalPorDocumentoIdentidadHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Personal> Handle(ObtenerPersonalesPorDocumentoIdentidadQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorDocumentoIdentidad(request.tipoDocumentoId, request.documentoIdentidad);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error al obtener el personal {request.tipoDocumentoId}-{request.documentoIdentidad}");
            throw;
        }
    }
}
