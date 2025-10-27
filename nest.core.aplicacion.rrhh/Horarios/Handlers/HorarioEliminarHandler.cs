using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Horarios.Commands;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.aplicacion.rrhh.Horarios.Handlers
{
    public class HorarioEliminarHandler : IRequestHandler<HorarioEliminarCommand, bool>
    {
        private readonly IHorarioRepository repository;
        private readonly ILogger<HorarioEliminarHandler> logger;

        public HorarioEliminarHandler(IHorarioRepository repository, ILogger<HorarioEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(HorarioEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar el horario {Id}", request.Id);
                throw;
            }
        }
    }
}
