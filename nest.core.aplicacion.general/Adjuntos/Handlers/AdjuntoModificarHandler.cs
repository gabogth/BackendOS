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
    public class AdjuntoModificarHandler : IRequestHandler<AdjuntoModificarCommand, Adjunto>
    {
        private readonly IAdjuntoRepository repository;
        private readonly IAdjuntoConfigProviderRepository configRepository;
        private readonly IReadOnlyDictionary<AdjuntoProviderEnum, IAdjuntoStorageService> storageServices;
        private readonly ILogger<AdjuntoModificarHandler> logger;

        public AdjuntoModificarHandler(
            IAdjuntoRepository repository,
            IAdjuntoConfigProviderRepository configRepository,
            IEnumerable<IAdjuntoStorageService> storageServices,
            ILogger<AdjuntoModificarHandler> logger)
        {
            this.repository = repository;
            this.configRepository = configRepository;
            this.logger = logger;
            this.storageServices = storageServices.ToDictionary(service => service.Provider);
        }

        public async Task<Adjunto> Handle(AdjuntoModificarCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.Content);
            try
            {
                var actual = await repository.ObtenerPorId(request.Id);
                var config = await configRepository.ObtenerPorId(request.Modulo);
                var storage = ResolveStorage(config.AdjuntoProvider);
                var contentType = GetContentType(request.ContentType);
                var uploadResult = await storage.UploadAsync(request.Content, request.FileName, contentType, config.Container, config.MainPath, cancellationToken);

                var entity = new Adjunto
                {
                    Id = request.Id,
                    FileName = request.FileName,
                    ContentType = contentType,
                    Size = request.Size,
                    AdjuntoProvider = config.AdjuntoProvider,
                    Container = uploadResult.Container,
                    FullPath = uploadResult.FullPath,
                    NombreGenerado = uploadResult.NombreGenerado
                };

                var response = await repository.Modificar(entity);
                await ResolveStorage(actual.AdjuntoProvider).DeleteAsync(actual.Container, actual.FullPath, cancellationToken);
                return response;
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
