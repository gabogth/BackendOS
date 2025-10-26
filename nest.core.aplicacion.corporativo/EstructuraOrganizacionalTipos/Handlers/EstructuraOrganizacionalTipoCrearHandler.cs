using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Handlers
{
    public class EstructuraOrganizacionalTipoCrearHandler : IRequestHandler<EstructuraOrganizacionalTipoCrearCommand, EstructuraOrganizacionalTipo>
    {
        private readonly IEstructuraOrganizacionalTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<EstructuraOrganizacionalTipoCrearHandler> logger;

        public EstructuraOrganizacionalTipoCrearHandler(IEstructuraOrganizacionalTipoRepository repository, IMapper mapper, ILogger<EstructuraOrganizacionalTipoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<EstructuraOrganizacionalTipo> Handle(EstructuraOrganizacionalTipoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<EstructuraOrganizacionalTipo>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear el tipo de estructura organizacional");
                throw;
            }
        }
    }
}
