using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;
using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Handlers
{
    public class CuentaContableModificarHandler : IRequestHandler<CuentaContableModificarCommand, CuentaContable>
    {
        private readonly ICuentaContableRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<CuentaContableModificarHandler> logger;

        public CuentaContableModificarHandler(ICuentaContableRepository repository, IMapper mapper, ILogger<CuentaContableModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CuentaContable> Handle(CuentaContableModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<CuentaContable>(request);
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
