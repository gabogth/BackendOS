using MediatR;
using nest.core.dominio.General.AdjuntoTipoEntities;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.Features.PersonaAdjuntos.Commands;

public record CreatePersonaAdjuntoCommand(
    int EmpresaId,
    int PersonaId,
    long AdjuntoId,
    AdjuntoTipoEnum AdjuntoTipoId,
    bool EsFotoPrincipal) : IRequest<PersonaAdjunto>;

public class CreatePersonaAdjuntoCommandHandler(IPersonaAdjuntoRepository repository)
    : IRequestHandler<CreatePersonaAdjuntoCommand, PersonaAdjunto>
{
    public Task<PersonaAdjunto> Handle(CreatePersonaAdjuntoCommand request, CancellationToken cancellationToken)
    {
        var dto = new PersonaAdjuntoCrearDto
        {
            EmpresaId = request.EmpresaId,
            PersonaId = request.PersonaId,
            AdjuntoId = request.AdjuntoId,
            AdjuntoTipoId = request.AdjuntoTipoId,
            EsFotoPrincipal = request.EsFotoPrincipal,
            Id = 0
        };
        return repository.Agregar(dto);
    }
}

public record UpdatePersonaAdjuntoCommand(
    long Id,
    int EmpresaId,
    int PersonaId,
    long AdjuntoId,
    AdjuntoTipoEnum AdjuntoTipoId,
    bool EsFotoPrincipal) : IRequest<PersonaAdjunto>;

public class UpdatePersonaAdjuntoCommandHandler(IPersonaAdjuntoRepository repository)
    : IRequestHandler<UpdatePersonaAdjuntoCommand, PersonaAdjunto>
{
    public Task<PersonaAdjunto> Handle(UpdatePersonaAdjuntoCommand request, CancellationToken cancellationToken)
    {
        var dto = new PersonaAdjuntoCrearDto
        {
            Id = request.Id,
            EmpresaId = request.EmpresaId,
            PersonaId = request.PersonaId,
            AdjuntoId = request.AdjuntoId,
            AdjuntoTipoId = request.AdjuntoTipoId,
            EsFotoPrincipal = request.EsFotoPrincipal
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeletePersonaAdjuntoCommand(long Id) : IRequest<Unit>;

public class DeletePersonaAdjuntoCommandHandler(IPersonaAdjuntoRepository repository)
    : IRequestHandler<DeletePersonaAdjuntoCommand, Unit>
{
    public async Task<Unit> Handle(DeletePersonaAdjuntoCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
