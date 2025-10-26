using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Commands;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Handlers
{
    public class OrdenServicioTipoCrearHandler : IRequestHandler<OrdenServicioTipoCrearCommand, OrdenServicioTipo>
    {
        private readonly IOrdenServicioTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenServicioTipoCrearCommand> logger;

        public OrdenServicioTipoCrearHandler(IOrdenServicioTipoRepository repository, IMapper mapper, ILogger<OrdenServicioTipoCrearCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioTipo> Handle(OrdenServicioTipoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenServicioTipo>(request);
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
