using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Commands
{
    public sealed record AdjuntoConfigProviderModificarCommand(
        AdjuntoConfigProviderModuloEnum Id,
        string Nombre,
        string NombreCorto,
        AdjuntoProviderEnum AdjuntoProvider,
        string Container,
        string MainPath,
        bool Activo
    ) : IRequest<AdjuntoConfigProvider>, ICommandBase;
}
