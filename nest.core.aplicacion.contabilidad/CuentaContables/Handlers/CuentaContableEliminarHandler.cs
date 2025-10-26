using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;
using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Handlers
{
    public class CuentaContableEliminarHandler : IRequestHandler<CuentaContableEliminarCommand, Unit>
    {
        private readonly ICuentaContableRepository repository;
        private readonly ILogger<CuentaContableEliminarHandler> logger;

        public CuentaContableEliminarHandler(ICuentaContableRepository repository, ILogger<CuentaContableEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(CuentaContableEliminarCommand request, CancellationToken cancellationToken)
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
