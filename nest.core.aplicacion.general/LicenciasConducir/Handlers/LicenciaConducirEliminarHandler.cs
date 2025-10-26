using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.LicenciasConducir.Commands;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.LicenciasConducir.Handlers
{
    public sealed class LicenciaConducirEliminarHandler : IRequestHandler<LicenciaConducirEliminarCommand, bool>
    {
        private readonly ILicenciaConducirRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<LicenciaConducirEliminarHandler> logger;

        public LicenciaConducirEliminarHandler(
            ILicenciaConducirRepository repository,
            IMapper mapper,
            ILogger<LicenciaConducirEliminarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<bool> Handle(LicenciaConducirEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
