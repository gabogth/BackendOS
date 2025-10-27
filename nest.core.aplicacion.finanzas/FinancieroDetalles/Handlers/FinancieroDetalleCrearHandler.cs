using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Commands;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Handlers
{
    internal class FinancieroDetalleCrearHandler : IRequestHandler<FinancieroDetalleCrearCommand, FinancieroDetalle>
    {
        private readonly IFinancieroDetalleRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<FinancieroDetalleCrearHandler> logger;

        public FinancieroDetalleCrearHandler(IFinancieroDetalleRepository repository, IMapper mapper, ILogger<FinancieroDetalleCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<FinancieroDetalle> Handle(FinancieroDetalleCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<FinancieroDetalle>(request);
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
