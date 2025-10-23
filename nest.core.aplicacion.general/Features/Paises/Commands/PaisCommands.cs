using MediatR;
using nest.core.dominio.General.PaisEntities;

namespace nest.core.aplicacion.general.Features.Paises.Commands;

public record CreatePaisCommand(string Nombre, string CodigoIso, string CodigoTelefono) : IRequest<Pais>;

public class CreatePaisCommandHandler(IPaisRepository repository)
    : IRequestHandler<CreatePaisCommand, Pais>
{
    public Task<Pais> Handle(CreatePaisCommand request, CancellationToken cancellationToken)
    {
        var dto = new PaisCrearDto
        {
            Nombre = request.Nombre,
            CodigoIso = request.CodigoIso,
            CodigoTelefono = request.CodigoTelefono
        };
        return repository.Agregar(dto);
    }
}

public record UpdatePaisCommand(int Id, string Nombre, string CodigoIso, string CodigoTelefono) : IRequest<Pais>;

public class UpdatePaisCommandHandler(IPaisRepository repository)
    : IRequestHandler<UpdatePaisCommand, Pais>
{
    public Task<Pais> Handle(UpdatePaisCommand request, CancellationToken cancellationToken)
    {
        var dto = new PaisCrearDto
        {
            Nombre = request.Nombre,
            CodigoIso = request.CodigoIso,
            CodigoTelefono = request.CodigoTelefono
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeletePaisCommand(int Id) : IRequest<Unit>;

public class DeletePaisCommandHandler(IPaisRepository repository)
    : IRequestHandler<DeletePaisCommand, Unit>
{
    public async Task<Unit> Handle(DeletePaisCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
