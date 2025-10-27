using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Commands;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Handlers
{
    internal class FinancieroDetalleModificarHandler : IRequestHandler<FinancieroDetalleModificarCommand, FinancieroDetalle>
    {
        private readonly IFinancieroDetalleRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<FinancieroDetalleModificarHandler> logger;

        public FinancieroDetalleModificarHandler(IFinancieroDetalleRepository repository, IMapper mapper, ILogger<FinancieroDetalleModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<FinancieroDetalle> Handle(FinancieroDetalleModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<FinancieroDetalle>(request);
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
