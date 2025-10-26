using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Adjuntos.Queries;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.Adjuntos.Handlers
{
    internal class ObtenerUrlDescargaHandler : IRequestHandler<ObtenerUrlDescargaQuery, string>
    {
        private readonly IAdjuntoRepository repository;
        private readonly IReadOnlyDictionary<AdjuntoProviderEnum, IAdjuntoStorageService> storageServices;
        private readonly ILogger<ObtenerUrlDescargaHandler> logger;

        public ObtenerUrlDescargaHandler(
            IAdjuntoRepository repository,
            IEnumerable<IAdjuntoStorageService> storageServices,
            ILogger<ObtenerUrlDescargaHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
            this.storageServices = storageServices.ToDictionary(service => service.Provider);
        }

        public async Task<string> Handle(ObtenerUrlDescargaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var adjunto = await repository.ObtenerPorId(request.Id);
                var storage = ResolveStorage(adjunto.AdjuntoProvider);
                return await storage.GetUrlAsync(adjunto.Container, adjunto.FullPath, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        private IAdjuntoStorageService ResolveStorage(AdjuntoProviderEnum provider)
        {
            if (!storageServices.TryGetValue(provider, out var storageService))
                throw new InvalidOperationException($"No se encontró un almacenamiento configurado para el proveedor {provider}.");
            return storageService;
        }
    }
}
