using System.IO;
using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.Adjuntos.Commands
{
    public sealed record AdjuntoCrearCommand(
        AdjuntoConfigProviderModuloEnum Modulo,
        Stream Content,
        string FileName,
        string? ContentType,
        long Size
    ) : IRequest<Adjunto>, ICommandBase;
}
