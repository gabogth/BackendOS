using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Modulos.Commands;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Modulo.Repository;

namespace nest.core.aplicacion.security.Modulos.Handlers;

public class ModuloCrearHandler : IRequestHandler<ModuloCrearCommand, Modulo>
{
    private readonly IModuloRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<ModuloCrearHandler> logger;

    public ModuloCrearHandler(IModuloRepository repository, IMapper mapper, ILogger<ModuloCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Modulo> Handle(ModuloCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<Modulo>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear el módulo {Nombre}", request.Nombre);
            throw;
        }
    }
}
