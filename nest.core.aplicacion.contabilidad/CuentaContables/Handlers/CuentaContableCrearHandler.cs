using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;
using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Handlers
{
    public class CuentaContableCrearHandler : IRequestHandler<CuentaContableCrearCommand, CuentaContable>
    {
        private readonly ICuentaContableRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<CuentaContableCrearHandler> logger;

        public CuentaContableCrearHandler(ICuentaContableRepository repository, IMapper mapper, ILogger<CuentaContableCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CuentaContable> Handle(CuentaContableCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<CuentaContable>(request);
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
