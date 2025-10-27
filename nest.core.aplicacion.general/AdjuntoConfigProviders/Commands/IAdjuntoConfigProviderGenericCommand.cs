using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Commands
{
    public interface IAdjuntoConfigProviderGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        AdjuntoProviderEnum AdjuntoProvider { get; }
        string Container { get; }
        string MainPath { get; }
        bool Activo { get; }
    }
}
