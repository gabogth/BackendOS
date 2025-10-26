using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Handlers
{
    public class OrdenServicioCabeceraModificarHandler : IRequestHandler<OrdenServicioCabeceraModificarCommand, OrdenServicioCabecera>
    {
        private readonly IOrdenServicioCabeceraRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenServicioCabeceraModificarCommand> logger;

        public OrdenServicioCabeceraModificarHandler(IOrdenServicioCabeceraRepository repository, IMapper mapper, ILogger<OrdenServicioCabeceraModificarCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioCabecera> Handle(OrdenServicioCabeceraModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenServicioCabecera>(request);
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
