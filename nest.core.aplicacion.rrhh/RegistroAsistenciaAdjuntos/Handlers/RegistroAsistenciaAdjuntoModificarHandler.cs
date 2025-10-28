using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Handlers;

public class RegistroAsistenciaAdjuntoModificarHandler : IRequestHandler<RegistroAsistenciaAdjuntoModificarCommand, RegistroAsistenciaAdjunto>
{
    private readonly IRegistroAsistenciaAdjuntoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<RegistroAsistenciaAdjuntoModificarHandler> logger;

    public RegistroAsistenciaAdjuntoModificarHandler(IRegistroAsistenciaAdjuntoRepository repository, IMapper mapper, ILogger<RegistroAsistenciaAdjuntoModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<RegistroAsistenciaAdjunto> Handle(RegistroAsistenciaAdjuntoModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<RegistroAsistenciaAdjunto>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el adjunto del registro de asistencia {Id}", request.RegistroAsistenciaId);
            throw;
        }
    }
}
