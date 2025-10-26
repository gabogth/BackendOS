using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Handlers
{
    public class OrdenTrabajoPersonalCrearHandler : IRequestHandler<OrdenTrabajoPersonalCrearCommand, OrdenTrabajoPersonal>
    {
        private readonly IOrdenTrabajoPersonalRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoPersonalCrearHandler> logger;

        public OrdenTrabajoPersonalCrearHandler(IOrdenTrabajoPersonalRepository repository, IMapper mapper, ILogger<OrdenTrabajoPersonalCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoPersonal> Handle(OrdenTrabajoPersonalCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoPersonal>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al registrar el personal de la orden de trabajo");
                throw;
            }
        }
    }
}
