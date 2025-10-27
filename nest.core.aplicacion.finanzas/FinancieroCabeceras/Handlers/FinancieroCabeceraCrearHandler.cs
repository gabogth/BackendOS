using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Handlers
{
    internal class FinancieroCabeceraCrearHandler : IRequestHandler<FinancieroCabeceraCrearCommand, FinancieroCabecera>
    {
        private readonly IFinancieroCabeceraRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<FinancieroCabeceraCrearHandler> logger;

        public FinancieroCabeceraCrearHandler(IFinancieroCabeceraRepository repository, IMapper mapper, ILogger<FinancieroCabeceraCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<FinancieroCabecera> Handle(FinancieroCabeceraCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<FinancieroCabecera>(request);
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
