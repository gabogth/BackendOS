using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Handlers
{
    public class OrdenTrabajoDetalleCrearHandler : IRequestHandler<OrdenTrabajoDetalleCrearCommand, OrdenTrabajoDetalle>
    {
        private readonly IOrdenTrabajoDetalleRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoDetalleCrearHandler> logger;

        public OrdenTrabajoDetalleCrearHandler(IOrdenTrabajoDetalleRepository repository, IMapper mapper, ILogger<OrdenTrabajoDetalleCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoDetalle> Handle(OrdenTrabajoDetalleCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoDetalle>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al registrar el detalle de la orden de trabajo");
                throw;
            }
        }
    }
}
