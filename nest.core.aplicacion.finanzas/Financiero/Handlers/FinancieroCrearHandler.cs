using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Financiero.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Handlers
{
    internal class FinancieroCrearHandler : IRequestHandler<FinancieroCrearCommand, FinancieroCabecera>
    {
        private readonly IFinancieroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<FinancieroCrearHandler> logger;

        public FinancieroCrearHandler(IFinancieroRepository repository, IMapper mapper, ILogger<FinancieroCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<FinancieroCabecera> Handle(FinancieroCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cabecera = mapper.Map<FinancieroCabecera>(request);
                var detalles = request.Detalles ?? new List<FinancieroDetalleEntrada>();
                cabecera.FinancieroDetalles = mapper.Map<List<FinancieroDetalle>>(detalles);
                return await repository.Agregar(cabecera, request.Transaccional);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
