using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Personales.Queries;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Handlers;

public class ObtenerPersonalPorIdHandler : IRequestHandler<ObtenerPersonalPorIdQuery, Personal>
{
    private readonly IPersonalRepository repository;
    private readonly ILogger<ObtenerPersonalPorIdHandler> logger;

    public ObtenerPersonalPorIdHandler(IPersonalRepository repository, ILogger<ObtenerPersonalPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Personal> Handle(ObtenerPersonalPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el personal {Id}", request.Id);
            throw;
        }
    }
}
