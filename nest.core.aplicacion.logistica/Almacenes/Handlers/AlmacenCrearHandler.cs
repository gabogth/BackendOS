using AutoMapper;
using MediatR;
using nest.core.aplicacion.logistica.Almacenes.Commands;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class AlmacenCrearHandler : IRequestHandler<AlmacenCrearCommand, Almacen>
{
    private readonly IAlmacenRepository repository;
    private readonly IMapper mapper;

    public AlmacenCrearHandler(IAlmacenRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public Task<Almacen> Handle(AlmacenCrearCommand request, CancellationToken cancellationToken)
        => repository.Agregar(mapper.Map<Almacen>(request));
}
