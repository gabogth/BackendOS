using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Commands;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Handlers
{
    internal class FinancieroDetalleEliminarHandler : IRequestHandler<FinancieroDetalleEliminarCommand, Unit>
    {
        private readonly IFinancieroDetalleRepository repository;
        private readonly ILogger<FinancieroDetalleEliminarHandler> logger;

        public FinancieroDetalleEliminarHandler(IFinancieroDetalleRepository repository, ILogger<FinancieroDetalleEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(FinancieroDetalleEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
