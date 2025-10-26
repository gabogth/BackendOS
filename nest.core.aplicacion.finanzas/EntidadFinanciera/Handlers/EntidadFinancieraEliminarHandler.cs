using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.EntidadFinanciera.Commands;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;

namespace nest.core.aplicacion.finanzas.EntidadFinanciera.Handlers
{
    internal class EntidadFinancieraEliminarHandler : IRequestHandler<EntidadFinancieraEliminarCommand, bool>
    {
        private readonly IEntidadFinancieraRepository repository;
        private readonly ILogger<EntidadFinancieraEliminarHandler> logger;

        public EntidadFinancieraEliminarHandler(IEntidadFinancieraRepository repository, ILogger<EntidadFinancieraEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(EntidadFinancieraEliminarCommand request, CancellationToken cancellationToken)
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
