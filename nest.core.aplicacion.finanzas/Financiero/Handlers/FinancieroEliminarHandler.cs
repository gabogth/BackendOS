using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Financiero.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Handlers
{
    internal class FinancieroEliminarHandler : IRequestHandler<FinancieroEliminarCommand, bool>
    {
        private readonly IFinancieroRepository repository;
        private readonly ILogger<FinancieroEliminarHandler> logger;

        public FinancieroEliminarHandler(IFinancieroRepository repository, ILogger<FinancieroEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(FinancieroEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
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
