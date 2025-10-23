using MediatR;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.Features.AdjuntoConfigProviders.Queries;

public record GetAdjuntoConfigProvidersQuery() : IRequest<List<AdjuntoConfigProvider>>;

public class GetAdjuntoConfigProvidersQueryHandler(IAdjuntoConfigProviderRepository repository)
    : IRequestHandler<GetAdjuntoConfigProvidersQuery, List<AdjuntoConfigProvider>>
{
    public Task<List<AdjuntoConfigProvider>> Handle(GetAdjuntoConfigProvidersQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetAdjuntoConfigProviderByIdQuery(AdjuntoConfigProviderModuloEnum Id) : IRequest<AdjuntoConfigProvider>;

public class GetAdjuntoConfigProviderByIdQueryHandler(IAdjuntoConfigProviderRepository repository)
    : IRequestHandler<GetAdjuntoConfigProviderByIdQuery, AdjuntoConfigProvider>
{
    public Task<AdjuntoConfigProvider> Handle(GetAdjuntoConfigProviderByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}

public record GetAdjuntoConfigProvidersActivosQuery() : IRequest<List<AdjuntoConfigProvider>>;

public class GetAdjuntoConfigProvidersActivosQueryHandler(IAdjuntoConfigProviderRepository repository)
    : IRequestHandler<GetAdjuntoConfigProvidersActivosQuery, List<AdjuntoConfigProvider>>
{
    public Task<List<AdjuntoConfigProvider>> Handle(GetAdjuntoConfigProvidersActivosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerActivos();
}
