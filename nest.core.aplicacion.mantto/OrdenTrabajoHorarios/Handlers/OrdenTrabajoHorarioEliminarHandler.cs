using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Handlers
{
    public class OrdenTrabajoHorarioEliminarHandler : IRequestHandler<OrdenTrabajoHorarioEliminarCommand, Unit>
    {
        private readonly IOrdenTrabajoHorarioRepository repository;
        private readonly ILogger<OrdenTrabajoHorarioEliminarHandler> logger;

        public OrdenTrabajoHorarioEliminarHandler(IOrdenTrabajoHorarioRepository repository, ILogger<OrdenTrabajoHorarioEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(OrdenTrabajoHorarioEliminarCommand request, CancellationToken cancellationToken)
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
