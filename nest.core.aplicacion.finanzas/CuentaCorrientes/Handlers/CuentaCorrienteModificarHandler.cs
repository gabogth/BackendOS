using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Commands;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Handlers
{
    internal class CuentaCorrienteModificarHandler : IRequestHandler<CuentaCorrienteModificarCommand, CuentaCorriente>
    {
        private readonly ICuentaCorrienteRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<CuentaCorrienteModificarHandler> logger;

        public CuentaCorrienteModificarHandler(ICuentaCorrienteRepository repository, IMapper mapper, ILogger<CuentaCorrienteModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CuentaCorriente> Handle(CuentaCorrienteModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<CuentaCorriente>(request);
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
