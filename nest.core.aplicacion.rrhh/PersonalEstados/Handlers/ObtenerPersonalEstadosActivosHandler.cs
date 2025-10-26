using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalEstados.Queries;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Handlers;

public class ObtenerPersonalEstadosActivosHandler : IRequestHandler<ObtenerPersonalEstadosActivosQuery, List<PersonalEstado>>
{
    private readonly IPersonalEstadoRepository repository;
    private readonly ILogger<ObtenerPersonalEstadosActivosHandler> logger;

    public ObtenerPersonalEstadosActivosHandler(IPersonalEstadoRepository repository, ILogger<ObtenerPersonalEstadosActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<PersonalEstado>> Handle(ObtenerPersonalEstadosActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerActivos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los estados de personal activos");
            throw;
        }
    }
}
