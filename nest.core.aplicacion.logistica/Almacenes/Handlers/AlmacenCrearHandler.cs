using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.logistica.Almacenes.Commands;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class AlmacenCrearHandler : IRequestHandler<AlmacenCrearCommand, Almacen>
{
    private readonly IAlmacenRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<AlmacenCrearHandler> logger;

    public AlmacenCrearHandler(IAlmacenRepository repository, IMapper mapper, ILogger<AlmacenCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Almacen> Handle(AlmacenCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<Almacen>(request);
            return await this.repository.Agregar(entity);
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Error al crear el almacén {Nombre}", request.Nombre);
            throw;
        }
    }
}
