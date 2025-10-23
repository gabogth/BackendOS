using MediatR;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Features.Sexos.Commands;

public record CreateSexoCommand(string Nombre, string NombreCorto) : IRequest<Sexo>;

public class CreateSexoCommandHandler(ISexoRepository repository)
    : IRequestHandler<CreateSexoCommand, Sexo>
{
    public Task<Sexo> Handle(CreateSexoCommand request, CancellationToken cancellationToken)
    {
        var dto = new SexoCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto
        };
        return repository.Agregar(dto);
    }
}

public record UpdateSexoCommand(byte Id, string Nombre, string NombreCorto) : IRequest<Sexo>;

public class UpdateSexoCommandHandler(ISexoRepository repository)
    : IRequestHandler<UpdateSexoCommand, Sexo>
{
    public Task<Sexo> Handle(UpdateSexoCommand request, CancellationToken cancellationToken)
    {
        var dto = new SexoCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeleteSexoCommand(byte Id) : IRequest<Unit>;

public class DeleteSexoCommandHandler(ISexoRepository repository)
    : IRequestHandler<DeleteSexoCommand, Unit>
{
    public async Task<Unit> Handle(DeleteSexoCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
