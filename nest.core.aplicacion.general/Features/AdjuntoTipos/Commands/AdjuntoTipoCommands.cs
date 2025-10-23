using MediatR;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.Features.AdjuntoTipos.Commands;

public record CreateAdjuntoTipoCommand(string Nombre, string NombreCorto, bool Activo) : IRequest<AdjuntoTipo>;

public class CreateAdjuntoTipoCommandHandler(IAdjuntoTipoRepository repository)
    : IRequestHandler<CreateAdjuntoTipoCommand, AdjuntoTipo>
{
    public Task<AdjuntoTipo> Handle(CreateAdjuntoTipoCommand request, CancellationToken cancellationToken)
    {
        var dto = new AdjuntoTipoCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto,
            Activo = request.Activo
        };
        return repository.Agregar(dto);
    }
}

public record UpdateAdjuntoTipoCommand(AdjuntoTipoEnum Id, string Nombre, string NombreCorto, bool Activo) : IRequest<AdjuntoTipo>;

public class UpdateAdjuntoTipoCommandHandler(IAdjuntoTipoRepository repository)
    : IRequestHandler<UpdateAdjuntoTipoCommand, AdjuntoTipo>
{
    public Task<AdjuntoTipo> Handle(UpdateAdjuntoTipoCommand request, CancellationToken cancellationToken)
    {
        var dto = new AdjuntoTipoCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto,
            Activo = request.Activo
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeleteAdjuntoTipoCommand(AdjuntoTipoEnum Id) : IRequest<Unit>;

public class DeleteAdjuntoTipoCommandHandler(IAdjuntoTipoRepository repository)
    : IRequestHandler<DeleteAdjuntoTipoCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAdjuntoTipoCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
