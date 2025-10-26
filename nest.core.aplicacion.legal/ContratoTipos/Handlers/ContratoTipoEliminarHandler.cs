using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.legal.ContratoTipos.Commands;
using nest.core.dominio.Legal.ContratoTipoEntities;

namespace nest.core.aplicacion.legal.ContratoTipos.Handlers
{
    public class ContratoTipoEliminarHandler : IRequestHandler<ContratoTipoEliminarCommand, Unit>
    {
        private readonly IContratoTipoRepository repository;
        private readonly ILogger<ContratoTipoEliminarHandler> logger;

        public ContratoTipoEliminarHandler(IContratoTipoRepository repository, ILogger<ContratoTipoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(ContratoTipoEliminarCommand request, CancellationToken cancellationToken)
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
