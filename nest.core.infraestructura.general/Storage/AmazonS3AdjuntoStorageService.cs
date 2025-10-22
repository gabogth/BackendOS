using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using nest.core.dominio.General.AdjuntoEntities;

namespace nest.core.infraestructura.general.Storage
{
    public class AmazonS3AdjuntoStorageService : IAdjuntoStorageService
    {
        private readonly IAmazonS3 amazonS3;
        private readonly IOptionsMonitor<AmazonS3StorageOptions> options;
        private readonly ILogger<AmazonS3AdjuntoStorageService> logger;

        public AmazonS3AdjuntoStorageService(IAmazonS3 amazonS3, IOptionsMonitor<AmazonS3StorageOptions> options, ILogger<AmazonS3AdjuntoStorageService> logger)
        {
            this.amazonS3 = amazonS3;
            this.options = options;
            this.logger = logger;
        }

        public AdjuntoProviderEnum Provider => AdjuntoProviderEnum.AmazonS3;

        public async Task<AdjuntoStorageResult> UploadAsync(Stream content, string fileName, string contentType, string container, string path, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
            var settings = options.CurrentValue;
            var bucket = string.IsNullOrWhiteSpace(container) ? settings.DefaultBucketName : container;
            if (string.IsNullOrWhiteSpace(bucket))
                throw new InvalidOperationException("No se ha configurado un bucket para almacenar el adjunto.");

            string generatedName = $"{Guid.NewGuid():N}_{fileName}";
            string objectKey = BuildObjectKey(path, generatedName);

            if (content.CanSeek)
                content.Position = 0;

            var request = new PutObjectRequest
            {
                BucketName = bucket,
                Key = objectKey,
                InputStream = content,
                ContentType = contentType,
                AutoCloseStream = false
            };

            request.Metadata["original-filename"] = fileName;
            request.Metadata["uploaded-at"] = DateTimeOffset.UtcNow.ToString("O");

            await amazonS3.PutObjectAsync(request, cancellationToken);
            logger.LogInformation("Archivo {FileName} almacenado en S3 (Bucket: {Bucket}, Key: {Key}).", fileName, bucket, objectKey);

            return new AdjuntoStorageResult
            {
                Container = bucket,
                FullPath = objectKey,
                NombreGenerado = generatedName
            };
        }

        public async Task DeleteAsync(string container, string fullPath, CancellationToken cancellationToken = default)
        {
            var settings = options.CurrentValue;
            var bucket = string.IsNullOrWhiteSpace(container) ? settings.DefaultBucketName : container;
            if (string.IsNullOrWhiteSpace(bucket) || string.IsNullOrWhiteSpace(fullPath))
                return;

            var request = new DeleteObjectRequest
            {
                BucketName = bucket,
                Key = fullPath
            };

            await amazonS3.DeleteObjectAsync(request, cancellationToken);
            logger.LogInformation("Archivo eliminado de S3 (Bucket: {Bucket}, Key: {Key}).", bucket, fullPath);
        }

        private static string BuildObjectKey(string path, string fileName)
        {
            if (string.IsNullOrWhiteSpace(path))
                return fileName;

            string normalisedPath = path.Replace("\\", "/").Trim('/');
            return string.IsNullOrEmpty(normalisedPath)
                ? fileName
                : $"{normalisedPath}/{fileName}";
        }
    }
}
