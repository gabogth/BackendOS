using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Financiero.Commands;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Handlers
{
    internal class FinancieroDetalleCrearHandler : IRequestHandler<FinancieroDetalleCrearCommand, FinancieroDetalle>
    {
        private readonly IFinancieroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<FinancieroDetalleCrearHandler> logger;

        public FinancieroDetalleCrearHandler(IFinancieroRepository repository, IMapper mapper, ILogger<FinancieroDetalleCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<FinancieroDetalle> Handle(FinancieroDetalleCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var detalle = mapper.Map<FinancieroDetalle>(request);
                return await repository.AgregarDetalle(detalle);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
