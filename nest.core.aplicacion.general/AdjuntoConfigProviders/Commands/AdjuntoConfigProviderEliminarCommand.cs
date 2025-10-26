using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Commands
{
    public sealed record AdjuntoConfigProviderEliminarCommand(AdjuntoConfigProviderModuloEnum Id) : IRequest<Unit>, ICommandBase;
}
