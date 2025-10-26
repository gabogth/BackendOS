using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalEstados.Queries;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Handlers;

public class ObtenerPersonalEstadoPorIdHandler : IRequestHandler<ObtenerPersonalEstadoPorIdQuery, PersonalEstado>
{
    private readonly IPersonalEstadoRepository repository;
    private readonly ILogger<ObtenerPersonalEstadoPorIdHandler> logger;

    public ObtenerPersonalEstadoPorIdHandler(IPersonalEstadoRepository repository, ILogger<ObtenerPersonalEstadoPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<PersonalEstado> Handle(ObtenerPersonalEstadoPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el estado de personal {Id}", request.Id);
            throw;
        }
    }
}
