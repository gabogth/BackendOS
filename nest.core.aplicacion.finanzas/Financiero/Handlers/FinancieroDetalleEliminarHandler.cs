using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Financiero.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Handlers
{
    internal class FinancieroDetalleEliminarHandler : IRequestHandler<FinancieroDetalleEliminarCommand, bool>
    {
        private readonly IFinancieroRepository repository;
        private readonly ILogger<FinancieroDetalleEliminarHandler> logger;

        public FinancieroDetalleEliminarHandler(IFinancieroRepository repository, ILogger<FinancieroDetalleEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(FinancieroDetalleEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.EliminarDetalle(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
