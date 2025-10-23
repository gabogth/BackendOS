using System.IO;

namespace nest.core.aplicacion.general.Features.Adjuntos.Commands;

public class AdjuntoUploadDto
{
    public Stream Content { get; set; } = Stream.Null;
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long Size { get; set; }

    public override string ToString()
        => $"AdjuntoUploadDto [FileName={FileName}, ContentType={ContentType}, Size={Size}]";
}
