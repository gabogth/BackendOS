using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    public class RegistroAsistenciaEliminarHandler : IRequestHandler<RegistroAsistenciaEliminarCommand, bool>
    {
        private readonly IRegistroAsistenciaRepository repository;
        private readonly ILogger<RegistroAsistenciaEliminarHandler> logger;

        public RegistroAsistenciaEliminarHandler(IRegistroAsistenciaRepository repository, ILogger<RegistroAsistenciaEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(RegistroAsistenciaEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar el registro de asistencia {Id}", request.Id);
                throw;
            }
        }
    }
}
