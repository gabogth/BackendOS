using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Handlers
{
    public class EstructuraOrganizacionalTipoEliminarHandler : IRequestHandler<EstructuraOrganizacionalTipoEliminarCommand, bool>
    {
        private readonly IEstructuraOrganizacionalTipoRepository repository;
        private readonly ILogger<EstructuraOrganizacionalTipoEliminarHandler> logger;

        public EstructuraOrganizacionalTipoEliminarHandler(IEstructuraOrganizacionalTipoRepository repository, ILogger<EstructuraOrganizacionalTipoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(EstructuraOrganizacionalTipoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar el tipo de estructura organizacional");
                throw;
            }
        }
    }
}
