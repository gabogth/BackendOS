using nest.core.dominio.General.AdjuntoProviderEntities;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace nest.core.dominio.General.AdjuntoEntities
{
    public interface IAdjuntoStorageService
    {
        AdjuntoProviderEnum Provider { get; }
        Task<AdjuntoStorageResult> UploadAsync(Stream content, string fileName, string contentType, string container, string path, CancellationToken cancellationToken = default);
        Task DeleteAsync(string container, string fullPath, CancellationToken cancellationToken = default);
        Task<string> GetUrlAsync(string container, string fullPath, CancellationToken cancellationToken = default);
    }
}
