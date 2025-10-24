using Microsoft.Extensions.Logging;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.infraestructura.general.Storage
{
    public class LocalFileAdjuntoStorageService : IAdjuntoStorageService
    {
        private readonly ILogger<LocalFileAdjuntoStorageService> logger;

        public LocalFileAdjuntoStorageService(ILogger<LocalFileAdjuntoStorageService> logger)
        {
            this.logger = logger;
        }

        public AdjuntoProviderEnum Provider => AdjuntoProviderEnum.Local;

        public async Task<AdjuntoStorageResult> UploadAsync(Stream content, string fileName, string contentType, string container, string path, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
            ArgumentNullException.ThrowIfNull(content);

            string generatedName = $"{Guid.NewGuid():N}_{fileName}";
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (content.CanSeek)
                content.Position = 0;
            string destinationPath = Path.Combine(path, generatedName);

            await using (var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, useAsync: true))
            {
                await content.CopyToAsync(fileStream, cancellationToken);
            }

            logger.LogInformation("Archivo {FileName} almacenado localmente en {Path}.", fileName, path);

            return new AdjuntoStorageResult
            {
                Container = container,
                FullPath = destinationPath,
                NombreGenerado = generatedName
            };
        }

        public Task DeleteAsync(string container, string fullPath, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(fullPath))
                return Task.CompletedTask;

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                logger.LogInformation("Archivo eliminado del almacenamiento local en {Path}.", fullPath);
            }
            else
                logger.LogDebug("No se encontró el archivo local {Path} para eliminar.", fullPath);

            return Task.CompletedTask;
        }

        public Task<string> GetUrlAsync(string container, string fullPath, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(fullPath);
        }
    }
}
