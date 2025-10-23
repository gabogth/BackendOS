using MediatR;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general.Features.Provincias.Commands;

public record CreateProvinciaCommand(string Nombre, int DepartamentoId) : IRequest<Provincia>;

public class CreateProvinciaCommandHandler(IProvinciaRepository repository)
    : IRequestHandler<CreateProvinciaCommand, Provincia>
{
    public Task<Provincia> Handle(CreateProvinciaCommand request, CancellationToken cancellationToken)
    {
        var dto = new ProvinciaCrearDto
        {
            Nombre = request.Nombre,
            DepartamentoId = request.DepartamentoId
        };
        return repository.Agregar(dto);
    }
}

public record UpdateProvinciaCommand(int Id, string Nombre, int DepartamentoId) : IRequest<Provincia>;

public class UpdateProvinciaCommandHandler(IProvinciaRepository repository)
    : IRequestHandler<UpdateProvinciaCommand, Provincia>
{
    public Task<Provincia> Handle(UpdateProvinciaCommand request, CancellationToken cancellationToken)
    {
        var dto = new ProvinciaCrearDto
        {
            Nombre = request.Nombre,
            DepartamentoId = request.DepartamentoId
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeleteProvinciaCommand(int Id) : IRequest<Unit>;

public class DeleteProvinciaCommandHandler(IProvinciaRepository repository)
    : IRequestHandler<DeleteProvinciaCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProvinciaCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
