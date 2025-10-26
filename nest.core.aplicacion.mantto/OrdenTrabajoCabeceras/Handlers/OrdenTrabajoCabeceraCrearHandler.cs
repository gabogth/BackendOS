using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Handlers
{
    public class OrdenTrabajoCabeceraCrearHandler : IRequestHandler<OrdenTrabajoCabeceraCrearCommand, OrdenTrabajoCabecera>
    {
        private readonly IOrdenTrabajoCabeceraRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoCabeceraCrearCommand> logger;

        public OrdenTrabajoCabeceraCrearHandler(IOrdenTrabajoCabeceraRepository repository, IMapper mapper, ILogger<OrdenTrabajoCabeceraCrearCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoCabecera> Handle(OrdenTrabajoCabeceraCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoCabecera>(request);
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
