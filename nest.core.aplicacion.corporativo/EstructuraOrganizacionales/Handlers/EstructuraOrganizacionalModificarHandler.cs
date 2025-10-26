using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Handlers
{
    public class EstructuraOrganizacionalModificarHandler : IRequestHandler<EstructuraOrganizacionalModificarCommand, EstructuraOrganizacional>
    {
        private readonly IEstructuraOrganizacionalRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<EstructuraOrganizacionalModificarHandler> logger;

        public EstructuraOrganizacionalModificarHandler(IEstructuraOrganizacionalRepository repository, IMapper mapper, ILogger<EstructuraOrganizacionalModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<EstructuraOrganizacional> Handle(EstructuraOrganizacionalModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<EstructuraOrganizacional>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar la estructura organizacional");
                throw;
            }
        }
    }
}
