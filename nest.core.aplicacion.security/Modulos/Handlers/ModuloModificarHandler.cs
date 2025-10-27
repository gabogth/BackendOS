using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Modulos.Commands;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Modulo.Repository;

namespace nest.core.aplicacion.security.Modulos.Handlers;

public class ModuloModificarHandler : IRequestHandler<ModuloModificarCommand, Modulo>
{
    private readonly IModuloRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<ModuloModificarHandler> logger;

    public ModuloModificarHandler(IModuloRepository repository, IMapper mapper, ILogger<ModuloModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Modulo> Handle(ModuloModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<Modulo>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el módulo {Id}", request.Id);
            throw;
        }
    }
}
