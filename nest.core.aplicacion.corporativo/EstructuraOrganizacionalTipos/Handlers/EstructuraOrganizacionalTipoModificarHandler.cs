using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Handlers
{
    public class EstructuraOrganizacionalTipoModificarHandler : IRequestHandler<EstructuraOrganizacionalTipoModificarCommand, EstructuraOrganizacionalTipo>
    {
        private readonly IEstructuraOrganizacionalTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<EstructuraOrganizacionalTipoModificarHandler> logger;

        public EstructuraOrganizacionalTipoModificarHandler(IEstructuraOrganizacionalTipoRepository repository, IMapper mapper, ILogger<EstructuraOrganizacionalTipoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<EstructuraOrganizacionalTipo> Handle(EstructuraOrganizacionalTipoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<EstructuraOrganizacionalTipo>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar el tipo de estructura organizacional");
                throw;
            }
        }
    }
}
