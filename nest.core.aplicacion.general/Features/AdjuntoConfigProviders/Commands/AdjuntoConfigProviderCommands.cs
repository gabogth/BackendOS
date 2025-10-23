using MediatR;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.Features.AdjuntoConfigProviders.Commands;

public record CreateAdjuntoConfigProviderCommand(
    string Nombre,
    string NombreCorto,
    AdjuntoProviderEnum AdjuntoProvider,
    string Container,
    string MainPath,
    bool Activo) : IRequest<AdjuntoConfigProvider>;

public class CreateAdjuntoConfigProviderCommandHandler(IAdjuntoConfigProviderRepository repository)
    : IRequestHandler<CreateAdjuntoConfigProviderCommand, AdjuntoConfigProvider>
{
    public Task<AdjuntoConfigProvider> Handle(CreateAdjuntoConfigProviderCommand request, CancellationToken cancellationToken)
    {
        var dto = new AdjuntoConfigProviderCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto,
            AdjuntoProvider = request.AdjuntoProvider,
            Container = request.Container,
            MainPath = request.MainPath,
            Activo = request.Activo
        };
        return repository.Agregar(dto);
    }
}

public record UpdateAdjuntoConfigProviderCommand(
    AdjuntoConfigProviderModuloEnum Id,
    string Nombre,
    string NombreCorto,
    AdjuntoProviderEnum AdjuntoProvider,
    string Container,
    string MainPath,
    bool Activo) : IRequest<AdjuntoConfigProvider>;

public class UpdateAdjuntoConfigProviderCommandHandler(IAdjuntoConfigProviderRepository repository)
    : IRequestHandler<UpdateAdjuntoConfigProviderCommand, AdjuntoConfigProvider>
{
    public Task<AdjuntoConfigProvider> Handle(UpdateAdjuntoConfigProviderCommand request, CancellationToken cancellationToken)
    {
        var dto = new AdjuntoConfigProviderCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto,
            AdjuntoProvider = request.AdjuntoProvider,
            Container = request.Container,
            MainPath = request.MainPath,
            Activo = request.Activo
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeleteAdjuntoConfigProviderCommand(AdjuntoConfigProviderModuloEnum Id) : IRequest<Unit>;

public class DeleteAdjuntoConfigProviderCommandHandler(IAdjuntoConfigProviderRepository repository)
    : IRequestHandler<DeleteAdjuntoConfigProviderCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAdjuntoConfigProviderCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
