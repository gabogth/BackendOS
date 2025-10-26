using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Financiero.Commands;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Handlers
{
    internal class FinancieroDetalleModificarHandler : IRequestHandler<FinancieroDetalleModificarCommand, FinancieroDetalle>
    {
        private readonly IFinancieroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<FinancieroDetalleModificarHandler> logger;

        public FinancieroDetalleModificarHandler(IFinancieroRepository repository, IMapper mapper, ILogger<FinancieroDetalleModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<FinancieroDetalle> Handle(FinancieroDetalleModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var detalle = mapper.Map<FinancieroDetalle>(request);
                return await repository.ModificarDetalle(detalle);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
