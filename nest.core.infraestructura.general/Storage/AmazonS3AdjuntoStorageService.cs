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
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.infraestructura.general.Storage
{
    public class AmazonS3AdjuntoStorageService : IAdjuntoStorageService
    {
        private readonly IAmazonS3 amazonS3;
        private readonly ILogger<AmazonS3AdjuntoStorageService> logger;

        public AmazonS3AdjuntoStorageService(IAmazonS3 amazonS3, ILogger<AmazonS3AdjuntoStorageService> logger)
        {
            this.amazonS3 = amazonS3;
            this.logger = logger;
        }

        public AdjuntoProviderEnum Provider => AdjuntoProviderEnum.AmazonS3;

        public async Task<AdjuntoStorageResult> UploadAsync(Stream content, string fileName, string contentType, string container, string path, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
            ArgumentException.ThrowIfNullOrWhiteSpace(container);
            Console.WriteLine($"Iniciando carga de archivo a S3: FileName={fileName}, Container={container}, Path={path}");

            string generatedName = $"{Guid.NewGuid():N}_{fileName}";
            string objectKey = $"{path.Trim()}/{generatedName}";
            Console.WriteLine($"Generado Object Key: {objectKey}");

            if (content.CanSeek)
                content.Position = 0;

            var request = new PutObjectRequest
            {
                BucketName = container,
                Key = objectKey,
                InputStream = content,
                ContentType = contentType,
                AutoCloseStream = false
            };
            Console.WriteLine("Configurando metadatos para el objeto S3.");

            request.Metadata["original-filename"] = fileName;
            request.Metadata["uploaded-at"] = DateTimeOffset.UtcNow.ToString("O");

            var response = await amazonS3.PutObjectAsync(request, cancellationToken);
            Console.WriteLine($"PutObjectAsync Response: {response.HttpStatusCode}");
            logger.LogInformation("Archivo {FileName} almacenado en S3 (Bucket: {Bucket}, Key: {Key}).", fileName, container, objectKey);
            return new AdjuntoStorageResult
            {
                Container = container,
                FullPath = objectKey,
                NombreGenerado = generatedName
            };
        }

        public async Task DeleteAsync(string container, string fullPath, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(container) || string.IsNullOrWhiteSpace(fullPath))
                return;

            var request = new DeleteObjectRequest
            {
                BucketName = container,
                Key = fullPath
            };

            await amazonS3.DeleteObjectAsync(request, cancellationToken);
            logger.LogInformation("Archivo eliminado de S3 (Bucket: {Bucket}, Key: {Key}).", container, fullPath);
        }
    }
}
