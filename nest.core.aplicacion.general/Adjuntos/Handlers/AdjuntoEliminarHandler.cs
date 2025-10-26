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
    public class AdjuntoEliminarHandler : IRequestHandler<AdjuntoEliminarCommand, Unit>
    {
        private readonly IAdjuntoRepository repository;
        private readonly IReadOnlyDictionary<AdjuntoProviderEnum, IAdjuntoStorageService> storageServices;
        private readonly ILogger<AdjuntoEliminarHandler> logger;

        public AdjuntoEliminarHandler(
            IAdjuntoRepository repository,
            IEnumerable<IAdjuntoStorageService> storageServices,
            ILogger<AdjuntoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
            this.storageServices = storageServices.ToDictionary(service => service.Provider);
        }

        public async Task<Unit> Handle(AdjuntoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var adjunto = await repository.ObtenerPorId(request.Id);
                await repository.Eliminar(request.Id);
                await ResolveStorage(adjunto.AdjuntoProvider).DeleteAsync(adjunto.Container, adjunto.FullPath, cancellationToken);
                return Unit.Value;
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
