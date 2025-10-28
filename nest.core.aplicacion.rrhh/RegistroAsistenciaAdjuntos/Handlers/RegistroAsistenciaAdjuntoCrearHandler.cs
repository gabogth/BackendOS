using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Handlers;

public class RegistroAsistenciaAdjuntoCrearHandler : IRequestHandler<RegistroAsistenciaAdjuntoCrearCommand, RegistroAsistenciaAdjunto>
{
    private readonly IRegistroAsistenciaAdjuntoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<RegistroAsistenciaAdjuntoCrearHandler> logger;

    public RegistroAsistenciaAdjuntoCrearHandler(IRegistroAsistenciaAdjuntoRepository repository, IMapper mapper, ILogger<RegistroAsistenciaAdjuntoCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<RegistroAsistenciaAdjunto> Handle(RegistroAsistenciaAdjuntoCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<RegistroAsistenciaAdjunto>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear el adjunto para el registro de asistencia {Id}", request.RegistroAsistenciaId);
            throw;
        }
    }
}
