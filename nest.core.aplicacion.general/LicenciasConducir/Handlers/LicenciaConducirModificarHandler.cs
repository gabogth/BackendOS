using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.LicenciasConducir.Commands;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.LicenciasConducir.Handlers
{
    public sealed class LicenciaConducirModificarHandler : IRequestHandler<LicenciaConducirModificarCommand, LicenciaConducir>
    {
        private readonly ILicenciaConducirRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<LicenciaConducirModificarHandler> logger;

        public LicenciaConducirModificarHandler(
            ILicenciaConducirRepository repository,
            IMapper mapper,
            ILogger<LicenciaConducirModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<LicenciaConducir> Handle(LicenciaConducirModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<LicenciaConducir>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
