using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Financiero.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Handlers
{
    internal class FinancieroModificarHandler : IRequestHandler<FinancieroModificarCommand, FinancieroCabecera>
    {
        private readonly IFinancieroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<FinancieroModificarHandler> logger;

        public FinancieroModificarHandler(IFinancieroRepository repository, IMapper mapper, ILogger<FinancieroModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<FinancieroCabecera> Handle(FinancieroModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cabecera = mapper.Map<FinancieroCabecera>(request);
                var detalles = request.Detalles ?? new List<FinancieroDetalleEntrada>();
                cabecera.FinancieroDetalles = mapper.Map<List<FinancieroDetalle>>(detalles);
                return await repository.Modificar(cabecera, request.Transaccional);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
