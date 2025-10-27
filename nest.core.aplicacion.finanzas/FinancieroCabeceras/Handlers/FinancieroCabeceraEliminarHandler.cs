using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Handlers
{
    internal class FinancieroCabeceraEliminarHandler : IRequestHandler<FinancieroCabeceraEliminarCommand, Unit>
    {
        private readonly IFinancieroCabeceraRepository repository;
        private readonly ILogger<FinancieroCabeceraEliminarHandler> logger;

        public FinancieroCabeceraEliminarHandler(IFinancieroCabeceraRepository repository, ILogger<FinancieroCabeceraEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(FinancieroCabeceraEliminarCommand request, CancellationToken cancellationToken)
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
