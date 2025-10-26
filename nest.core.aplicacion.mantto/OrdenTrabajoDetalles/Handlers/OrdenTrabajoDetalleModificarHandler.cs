using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Handlers
{
    public class OrdenTrabajoDetalleModificarHandler : IRequestHandler<OrdenTrabajoDetalleModificarCommand, OrdenTrabajoDetalle>
    {
        private readonly IOrdenTrabajoDetalleRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoDetalleModificarHandler> logger;

        public OrdenTrabajoDetalleModificarHandler(IOrdenTrabajoDetalleRepository repository, IMapper mapper, ILogger<OrdenTrabajoDetalleModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoDetalle> Handle(OrdenTrabajoDetalleModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoDetalle>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al actualizar el detalle {DetalleId}", request.Id);
                throw;
            }
        }
    }
}
