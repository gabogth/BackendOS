using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Commands;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Handlers
{
    public class OrdenServicioTipoModificarHandler : IRequestHandler<OrdenServicioTipoModificarCommand, OrdenServicioTipo>
    {
        private readonly IOrdenServicioTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenServicioTipoModificarCommand> logger;

        public OrdenServicioTipoModificarHandler(IOrdenServicioTipoRepository repository, IMapper mapper, ILogger<OrdenServicioTipoModificarCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioTipo> Handle(OrdenServicioTipoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenServicioTipo>(request);
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
