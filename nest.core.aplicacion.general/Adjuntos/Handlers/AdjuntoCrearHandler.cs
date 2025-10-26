using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Adjuntos.Commands;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.Adjuntos.Handlers
{
    public class AdjuntoCrearHandler : IRequestHandler<AdjuntoCrearCommand, Adjunto>
    {
        private readonly IAdjuntoRepository repository;
        private readonly IAdjuntoConfigProviderRepository configRepository;
        private readonly IReadOnlyDictionary<AdjuntoProviderEnum, IAdjuntoStorageService> storageServices;
        private readonly ILogger<AdjuntoCrearHandler> logger;

        public AdjuntoCrearHandler(
            IAdjuntoRepository repository,
            IAdjuntoConfigProviderRepository configRepository,
            IEnumerable<IAdjuntoStorageService> storageServices,
            ILogger<AdjuntoCrearHandler> logger)
        {
            this.repository = repository;
            this.configRepository = configRepository;
            this.logger = logger;
            this.storageServices = storageServices.ToDictionary(service => service.Provider);
        }

        public async Task<Adjunto> Handle(AdjuntoCrearCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.Content);
            try
            {
                var config = await configRepository.ObtenerPorId(request.Modulo);
                var storage = ResolveStorage(config.AdjuntoProvider);
                var contentType = GetContentType(request.ContentType);
                var uploadResult = await storage.UploadAsync(request.Content, request.FileName, contentType, config.Container, config.MainPath, cancellationToken);

                var entity = new Adjunto
                {
                    FileName = request.FileName,
                    ContentType = contentType,
                    Size = request.Size,
                    AdjuntoProvider = config.AdjuntoProvider,
                    Container = uploadResult.Container,
                    FullPath = uploadResult.FullPath,
                    NombreGenerado = uploadResult.NombreGenerado
                };

                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                request.Content.Dispose();
            }
        }

        private IAdjuntoStorageService ResolveStorage(AdjuntoProviderEnum provider)
        {
            if (!storageServices.TryGetValue(provider, out var storageService))
                throw new InvalidOperationException($"No se encontró un almacenamiento configurado para el proveedor {provider}.");
            return storageService;
        }

        private static string GetContentType(string? contentType) =>
            string.IsNullOrWhiteSpace(contentType) ? "application/octet-stream" : contentType;
    }
}
