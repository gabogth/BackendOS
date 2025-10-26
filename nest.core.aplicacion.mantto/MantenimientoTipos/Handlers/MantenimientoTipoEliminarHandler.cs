using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Handlers
{
    public class MantenimientoTipoEliminarHandler : IRequestHandler<MantenimientoTipoEliminarCommand, bool>
    {
        private readonly IMantenimientoTipoRepository repository;
        private readonly ILogger<MantenimientoTipoEliminarHandler> logger;

        public MantenimientoTipoEliminarHandler(IMantenimientoTipoRepository repository, ILogger<MantenimientoTipoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(MantenimientoTipoEliminarCommand request, CancellationToken cancellationToken)
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
