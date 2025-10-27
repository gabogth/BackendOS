using nest.core.aplicacion.utils.Commands;
using System.IO;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.Adjuntos.Commands
{
    public interface IAdjuntoGenericCommand : ICommandBase
    {
        AdjuntoConfigProviderModuloEnum Modulo { get; }
        Stream Content { get; }
        string FileName { get; }
        string? ContentType { get; }
        long Size { get; }
    }
}
