using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Handlers
{
    public class EstructuraOrganizacionalCrearHandler : IRequestHandler<EstructuraOrganizacionalCrearCommand, EstructuraOrganizacional>
    {
        private readonly IEstructuraOrganizacionalRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<EstructuraOrganizacionalCrearHandler> logger;

        public EstructuraOrganizacionalCrearHandler(IEstructuraOrganizacionalRepository repository, IMapper mapper, ILogger<EstructuraOrganizacionalCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<EstructuraOrganizacional> Handle(EstructuraOrganizacionalCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<EstructuraOrganizacional>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear la estructura organizacional");
                throw;
            }
        }
    }
}
