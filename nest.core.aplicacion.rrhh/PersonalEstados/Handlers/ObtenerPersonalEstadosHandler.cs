using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalEstados.Queries;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Handlers;

public class ObtenerPersonalEstadosHandler : IRequestHandler<ObtenerPersonalEstadosQuery, List<PersonalEstado>>
{
    private readonly IPersonalEstadoRepository repository;
    private readonly ILogger<ObtenerPersonalEstadosHandler> logger;

    public ObtenerPersonalEstadosHandler(IPersonalEstadoRepository repository, ILogger<ObtenerPersonalEstadosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<PersonalEstado>> Handle(ObtenerPersonalEstadosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los estados de personal");
            throw;
        }
    }
}
