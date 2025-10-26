using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.OrigenFinancieros.Commands;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Handlers
{
    public class OrigenFinancieroEliminarHandler : IRequestHandler<OrigenFinancieroEliminarCommand, Unit>
    {
        private readonly IOrigenFinancieroRepository repository;
        private readonly ILogger<OrigenFinancieroEliminarHandler> logger;

        public OrigenFinancieroEliminarHandler(IOrigenFinancieroRepository repository, ILogger<OrigenFinancieroEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(OrigenFinancieroEliminarCommand request, CancellationToken cancellationToken)
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
