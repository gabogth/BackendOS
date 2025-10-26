using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<AdjuntoConfigProvider>>, IQueryBase;
}
