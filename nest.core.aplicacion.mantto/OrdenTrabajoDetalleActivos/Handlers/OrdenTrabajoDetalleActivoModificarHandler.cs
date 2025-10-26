using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Handlers
{
    public class OrdenTrabajoDetalleActivoModificarHandler : IRequestHandler<OrdenTrabajoDetalleActivoModificarCommand, OrdenTrabajoDetalleActivo>
    {
        private readonly IOrdenTrabajoDetalleActivoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoDetalleActivoModificarHandler> logger;

        public OrdenTrabajoDetalleActivoModificarHandler(IOrdenTrabajoDetalleActivoRepository repository, IMapper mapper, ILogger<OrdenTrabajoDetalleActivoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoDetalleActivo> Handle(OrdenTrabajoDetalleActivoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoDetalleActivo>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al actualizar el activo del detalle {DetalleActivoId}", request.Id);
                throw;
            }
        }
    }
}
