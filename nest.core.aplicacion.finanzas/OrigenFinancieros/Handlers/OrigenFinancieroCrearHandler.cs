using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.OrigenFinancieros.Commands;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Handlers
{
    public class OrigenFinancieroCrearHandler : IRequestHandler<OrigenFinancieroCrearCommand, OrigenFinanciero>
    {
        private readonly IOrigenFinancieroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrigenFinancieroCrearHandler> logger;

        public OrigenFinancieroCrearHandler(IOrigenFinancieroRepository repository, IMapper mapper, ILogger<OrigenFinancieroCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrigenFinanciero> Handle(OrigenFinancieroCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrigenFinanciero>(request);
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
