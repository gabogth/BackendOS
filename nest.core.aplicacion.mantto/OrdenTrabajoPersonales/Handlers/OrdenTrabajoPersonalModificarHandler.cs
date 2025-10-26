using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Handlers
{
    public class OrdenTrabajoPersonalModificarHandler : IRequestHandler<OrdenTrabajoPersonalModificarCommand, OrdenTrabajoPersonal>
    {
        private readonly IOrdenTrabajoPersonalRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoPersonalModificarHandler> logger;

        public OrdenTrabajoPersonalModificarHandler(IOrdenTrabajoPersonalRepository repository, IMapper mapper, ILogger<OrdenTrabajoPersonalModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoPersonal> Handle(OrdenTrabajoPersonalModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoPersonal>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al actualizar el personal de la orden {OrdenId}", request.OrdenTrabajoCabeceraId);
                throw;
            }
        }
    }
}
