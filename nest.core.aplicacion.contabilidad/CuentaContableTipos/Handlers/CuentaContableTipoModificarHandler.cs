using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Handlers
{
    public class CuentaContableTipoModificarHandler : IRequestHandler<CuentaContableTipoModificarCommand, CuentaContableTipo>
    {
        private readonly ICuentaContableTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<CuentaContableTipoModificarHandler> logger;

        public CuentaContableTipoModificarHandler(ICuentaContableTipoRepository repository, IMapper mapper, ILogger<CuentaContableTipoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CuentaContableTipo> Handle(CuentaContableTipoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<CuentaContableTipo>(request);
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
