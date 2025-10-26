using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.LicenciasConducir.Commands;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.LicenciasConducir.Handlers
{
    public sealed class LicenciaConducirCrearHandler : IRequestHandler<LicenciaConducirCrearCommand, LicenciaConducir>
    {
        private readonly ILicenciaConducirRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<LicenciaConducirCrearHandler> logger;

        public LicenciaConducirCrearHandler(
            ILicenciaConducirRepository repository,
            IMapper mapper,
            ILogger<LicenciaConducirCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<LicenciaConducir> Handle(LicenciaConducirCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<LicenciaConducir>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
