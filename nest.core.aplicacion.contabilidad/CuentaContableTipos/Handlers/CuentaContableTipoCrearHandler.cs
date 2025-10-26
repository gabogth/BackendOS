using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Handlers
{
    public class CuentaContableTipoCrearHandler : IRequestHandler<CuentaContableTipoCrearCommand, CuentaContableTipo>
    {
        private readonly ICuentaContableTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<CuentaContableTipoCrearHandler> logger;

        public CuentaContableTipoCrearHandler(ICuentaContableTipoRepository repository, IMapper mapper, ILogger<CuentaContableTipoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CuentaContableTipo> Handle(CuentaContableTipoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<CuentaContableTipo>(request);
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
