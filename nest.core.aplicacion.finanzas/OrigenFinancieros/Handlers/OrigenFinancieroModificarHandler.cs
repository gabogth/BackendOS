using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.OrigenFinancieros.Commands;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Handlers
{
    public class OrigenFinancieroModificarHandler : IRequestHandler<OrigenFinancieroModificarCommand, OrigenFinanciero>
    {
        private readonly IOrigenFinancieroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrigenFinancieroModificarHandler> logger;

        public OrigenFinancieroModificarHandler(IOrigenFinancieroRepository repository, IMapper mapper, ILogger<OrigenFinancieroModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrigenFinanciero> Handle(OrigenFinancieroModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrigenFinanciero>(request);
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
