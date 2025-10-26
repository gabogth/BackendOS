using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Handlers
{
    public class CuentaContableTipoEliminarHandler : IRequestHandler<CuentaContableTipoEliminarCommand, Unit>
    {
        private readonly ICuentaContableTipoRepository repository;
        private readonly ILogger<CuentaContableTipoEliminarHandler> logger;

        public CuentaContableTipoEliminarHandler(ICuentaContableTipoRepository repository, ILogger<CuentaContableTipoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(CuentaContableTipoEliminarCommand request, CancellationToken cancellationToken)
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
