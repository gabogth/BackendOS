using System.IO;

namespace nest.core.aplicacion.general.AdjuntoServices
{
    public class AdjuntoUploadDto
    {
        public Stream Content { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }

        public override string ToString()
        {
            return $"AdjuntoUploadDto [FileName={FileName}, ContentType={ContentType}, Size={Size}]";
        }
    }
}
