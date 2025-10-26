using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Handlers
{
    public class OrdenTrabajoCabeceraModificarHandler : IRequestHandler<OrdenTrabajoCabeceraModificarCommand, OrdenTrabajoCabecera>
    {
        private readonly IOrdenTrabajoCabeceraRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoCabeceraModificarCommand> logger;

        public OrdenTrabajoCabeceraModificarHandler(IOrdenTrabajoCabeceraRepository repository, IMapper mapper, ILogger<OrdenTrabajoCabeceraModificarCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoCabecera> Handle(OrdenTrabajoCabeceraModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoCabecera>(request);
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
