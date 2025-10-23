using MediatR;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Features.Distritos.Commands;

public record CreateDistritoCommand(string Nombre, int ProvinciaId) : IRequest<Distrito>;

public class CreateDistritoCommandHandler(IDistritoRepository repository)
    : IRequestHandler<CreateDistritoCommand, Distrito>
{
    public Task<Distrito> Handle(CreateDistritoCommand request, CancellationToken cancellationToken)
    {
        var dto = new DistritoCrearDto
        {
            Nombre = request.Nombre,
            ProvinciaId = request.ProvinciaId
        };
        return repository.Agregar(dto);
    }
}

public record UpdateDistritoCommand(int Id, string Nombre, int ProvinciaId) : IRequest<Distrito>;

public class UpdateDistritoCommandHandler(IDistritoRepository repository)
    : IRequestHandler<UpdateDistritoCommand, Distrito>
{
    public Task<Distrito> Handle(UpdateDistritoCommand request, CancellationToken cancellationToken)
    {
        var dto = new DistritoCrearDto
        {
            Nombre = request.Nombre,
            ProvinciaId = request.ProvinciaId
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeleteDistritoCommand(int Id) : IRequest<Unit>;

public class DeleteDistritoCommandHandler(IDistritoRepository repository)
    : IRequestHandler<DeleteDistritoCommand, Unit>
{
    public async Task<Unit> Handle(DeleteDistritoCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
