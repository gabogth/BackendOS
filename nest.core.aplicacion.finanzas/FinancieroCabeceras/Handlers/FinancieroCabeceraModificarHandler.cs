using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Handlers
{
    internal class FinancieroCabeceraModificarHandler : IRequestHandler<FinancieroCabeceraModificarCommand, FinancieroCabecera>
    {
        private readonly IFinancieroCabeceraRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<FinancieroCabeceraModificarHandler> logger;

        public FinancieroCabeceraModificarHandler(IFinancieroCabeceraRepository repository, IMapper mapper, ILogger<FinancieroCabeceraModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<FinancieroCabecera> Handle(FinancieroCabeceraModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<FinancieroCabecera>(request);
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
