using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Handlers;

public class RegistroAsistenciaPoliticaCrearHandler : IRequestHandler<RegistroAsistenciaPoliticaCrearCommand, RegistroAsistenciaPolitica>
{
    private readonly IRegistroAsistenciaPoliticaRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<RegistroAsistenciaPoliticaCrearHandler> logger;

    public RegistroAsistenciaPoliticaCrearHandler(IRegistroAsistenciaPoliticaRepository repository, IMapper mapper, ILogger<RegistroAsistenciaPoliticaCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<RegistroAsistenciaPolitica> Handle(RegistroAsistenciaPoliticaCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<RegistroAsistenciaPolitica>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear la política de asistencia {Nombre}", request.Nombre);
            throw;
        }
    }
}
