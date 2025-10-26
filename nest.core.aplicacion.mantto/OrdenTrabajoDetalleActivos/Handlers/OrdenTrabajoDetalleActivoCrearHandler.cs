using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Handlers
{
    public class OrdenTrabajoDetalleActivoCrearHandler : IRequestHandler<OrdenTrabajoDetalleActivoCrearCommand, OrdenTrabajoDetalleActivo>
    {
        private readonly IOrdenTrabajoDetalleActivoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoDetalleActivoCrearHandler> logger;

        public OrdenTrabajoDetalleActivoCrearHandler(IOrdenTrabajoDetalleActivoRepository repository, IMapper mapper, ILogger<OrdenTrabajoDetalleActivoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoDetalleActivo> Handle(OrdenTrabajoDetalleActivoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoDetalleActivo>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al registrar el activo del detalle");
                throw;
            }
        }
    }
}
