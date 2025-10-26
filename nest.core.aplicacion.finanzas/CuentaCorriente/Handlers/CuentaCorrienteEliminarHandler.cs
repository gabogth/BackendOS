using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.CuentaCorriente.Commands;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.aplicacion.finanzas.CuentaCorriente.Handlers
{
    internal class CuentaCorrienteEliminarHandler : IRequestHandler<CuentaCorrienteEliminarCommand, bool>
    {
        private readonly ICuentaCorrienteRepository repository;
        private readonly ILogger<CuentaCorrienteEliminarHandler> logger;

        public CuentaCorrienteEliminarHandler(ICuentaCorrienteRepository repository, ILogger<CuentaCorrienteEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(CuentaCorrienteEliminarCommand request, CancellationToken cancellationToken)
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
