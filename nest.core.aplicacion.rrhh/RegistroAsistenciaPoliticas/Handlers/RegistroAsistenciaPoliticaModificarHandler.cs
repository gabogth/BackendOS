using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Handlers;

public class RegistroAsistenciaPoliticaModificarHandler : IRequestHandler<RegistroAsistenciaPoliticaModificarCommand, RegistroAsistenciaPolitica>
{
    private readonly IRegistroAsistenciaPoliticaRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<RegistroAsistenciaPoliticaModificarHandler> logger;

    public RegistroAsistenciaPoliticaModificarHandler(IRegistroAsistenciaPoliticaRepository repository, IMapper mapper, ILogger<RegistroAsistenciaPoliticaModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<RegistroAsistenciaPolitica> Handle(RegistroAsistenciaPoliticaModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<RegistroAsistenciaPolitica>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar la política de asistencia {Id}", request.Id);
            throw;
        }
    }
}
