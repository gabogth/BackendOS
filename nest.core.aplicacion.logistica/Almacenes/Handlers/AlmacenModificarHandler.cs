using AutoMapper;
using MediatR;
using nest.core.aplicacion.logistica.Almacenes.Commands;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class AlmacenModificarHandler : IRequestHandler<AlmacenModificarCommand, Almacen>
{
    private readonly IAlmacenRepository repository;
    private readonly IMapper mapper;

    public AlmacenModificarHandler(IAlmacenRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public Task<Almacen> Handle(AlmacenModificarCommand request, CancellationToken cancellationToken)
        => repository.Modificar(mapper.Map<Almacen>(request));
}
