using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.infraestructura.general.Storage
{
    public class LocalFileAdjuntoStorageService : IAdjuntoStorageService
    {
        private readonly IOptionsMonitor<LocalFileStorageOptions> options;
        private readonly ILogger<LocalFileAdjuntoStorageService> logger;

        public LocalFileAdjuntoStorageService(IOptionsMonitor<LocalFileStorageOptions> options,
                                              ILogger<LocalFileAdjuntoStorageService> logger)
        {
            this.options = options;
            this.logger = logger;
        }

        public AdjuntoProviderEnum Provider => AdjuntoProviderEnum.Local;

        public async Task<AdjuntoStorageResult> UploadAsync(Stream content, string fileName, string contentType, string container, string path, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
            ArgumentNullException.ThrowIfNull(content);

            var settings = options.CurrentValue;
            string rootPath = ResolveRootPath(settings.RootPath);
            string containerName = ResolveContainer(container, settings.DefaultContainerName);

            string generatedName = $"{Guid.NewGuid():N}_{fileName}";
            string destinationDirectory = BuildDirectoryPath(rootPath, containerName, path);
            Directory.CreateDirectory(destinationDirectory);

            string destinationPath = Path.Combine(destinationDirectory, generatedName);
            if (content.CanSeek)
                content.Position = 0;

            await using (var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, useAsync: true))
            {
                await content.CopyToAsync(fileStream, cancellationToken);
            }

            logger.LogInformation("Archivo {FileName} almacenado localmente en {Path}.", fileName, destinationPath);

            return new AdjuntoStorageResult
            {
                Container = containerName,
                FullPath = BuildRelativePath(path, generatedName),
                NombreGenerado = generatedName
            };
        }

        public Task DeleteAsync(string container, string fullPath, CancellationToken cancellationToken = default)
        {
            var settings = options.CurrentValue;
            string rootPath = ResolveRootPath(settings.RootPath);
            string containerName = ResolveContainer(container, settings.DefaultContainerName);

            if (string.IsNullOrWhiteSpace(fullPath))
                return Task.CompletedTask;

            string targetPath = BuildFilePath(rootPath, containerName, fullPath);

            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
                logger.LogInformation("Archivo eliminado del almacenamiento local en {Path}.", targetPath);
            }
            else
            {
                logger.LogDebug("No se encontró el archivo local {Path} para eliminar.", targetPath);
            }

            return Task.CompletedTask;
        }

        private static string ResolveRootPath(string configuredRoot)
        {
            if (string.IsNullOrWhiteSpace(configuredRoot))
                throw new InvalidOperationException("La ruta raíz para el almacenamiento local de adjuntos no está configurada.");

            if (Path.IsPathRooted(configuredRoot))
                return configuredRoot;

            string baseDirectory = AppContext.BaseDirectory;
            return Path.GetFullPath(Path.Combine(baseDirectory, configuredRoot));
        }

        private static string ResolveContainer(string requestedContainer, string defaultContainer)
        {
            return string.IsNullOrWhiteSpace(requestedContainer) ? defaultContainer : requestedContainer;
        }

        private static string BuildDirectoryPath(string rootPath, string container, string path)
        {
            var segments = new List<string> { rootPath };
            if (!string.IsNullOrWhiteSpace(container))
                segments.Add(container);
            if (!string.IsNullOrWhiteSpace(path))
                segments.AddRange(SplitPath(path));
            return Path.Combine(segments.ToArray());
        }

        private static string BuildFilePath(string rootPath, string container, string fullPath)
        {
            var segments = new List<string> { rootPath };
            if (!string.IsNullOrWhiteSpace(container))
                segments.Add(container);
            segments.AddRange(SplitPath(fullPath));
            return Path.Combine(segments.ToArray());
        }

        private static string BuildRelativePath(string path, string fileName)
        {
            if (string.IsNullOrWhiteSpace(path))
                return fileName;

            string normalizedPath = string.Join('/', SplitPath(path));
            return string.IsNullOrEmpty(normalizedPath) ? fileName : $"{normalizedPath}/{fileName}";
        }

        private static IEnumerable<string> SplitPath(string path)
        {
            return path.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
