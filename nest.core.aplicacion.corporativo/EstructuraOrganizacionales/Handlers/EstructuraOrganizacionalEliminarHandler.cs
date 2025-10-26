using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Handlers
{
    public class EstructuraOrganizacionalEliminarHandler : IRequestHandler<EstructuraOrganizacionalEliminarCommand, bool>
    {
        private readonly IEstructuraOrganizacionalRepository repository;
        private readonly ILogger<EstructuraOrganizacionalEliminarHandler> logger;

        public EstructuraOrganizacionalEliminarHandler(IEstructuraOrganizacionalRepository repository, ILogger<EstructuraOrganizacionalEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(EstructuraOrganizacionalEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar la estructura organizacional");
                throw;
            }
        }
    }
}
