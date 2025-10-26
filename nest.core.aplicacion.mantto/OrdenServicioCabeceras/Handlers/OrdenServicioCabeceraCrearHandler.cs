using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Handlers
{
    public class OrdenServicioCabeceraCrearHandler : IRequestHandler<OrdenServicioCabeceraCrearCommand, OrdenServicioCabecera>
    {
        private readonly IOrdenServicioCabeceraRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenServicioCabeceraCrearCommand> logger;

        public OrdenServicioCabeceraCrearHandler(IOrdenServicioCabeceraRepository repository, IMapper mapper, ILogger<OrdenServicioCabeceraCrearCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioCabecera> Handle(OrdenServicioCabeceraCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenServicioCabecera>(request);
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
