using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.PuntoFinancieros.Commands;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Handlers
{
    public class PuntoFinancieroModificarHandler : IRequestHandler<PuntoFinancieroModificarCommand, PuntoFinanciero>
    {
        private readonly IPuntoFinancieroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PuntoFinancieroModificarHandler> logger;

        public PuntoFinancieroModificarHandler(IPuntoFinancieroRepository repository, IMapper mapper, ILogger<PuntoFinancieroModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<PuntoFinanciero> Handle(PuntoFinancieroModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<PuntoFinanciero>(request);
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
