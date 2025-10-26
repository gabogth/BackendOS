using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.PuntoFinancieros.Commands;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Handlers
{
    public class PuntoFinancieroCrearHandler : IRequestHandler<PuntoFinancieroCrearCommand, PuntoFinanciero>
    {
        private readonly IPuntoFinancieroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PuntoFinancieroCrearHandler> logger;

        public PuntoFinancieroCrearHandler(IPuntoFinancieroRepository repository, IMapper mapper, ILogger<PuntoFinancieroCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<PuntoFinanciero> Handle(PuntoFinancieroCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<PuntoFinanciero>(request);
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
