using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.CuentaCorriente.Commands;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.aplicacion.finanzas.CuentaCorriente.Handlers
{
    internal class CuentaCorrienteCrearHandler : IRequestHandler<CuentaCorrienteCrearCommand, CuentaCorriente>
    {
        private readonly ICuentaCorrienteRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<CuentaCorrienteCrearHandler> logger;

        public CuentaCorrienteCrearHandler(ICuentaCorrienteRepository repository, IMapper mapper, ILogger<CuentaCorrienteCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CuentaCorriente> Handle(CuentaCorrienteCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<CuentaCorriente>(request);
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
