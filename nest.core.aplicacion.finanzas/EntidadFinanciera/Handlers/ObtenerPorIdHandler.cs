using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.EntidadFinanciera.Queries;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;

namespace nest.core.aplicacion.finanzas.EntidadFinanciera.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, EntidadFinanciera>
    {
        private readonly IEntidadFinancieraRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IEntidadFinancieraRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<EntidadFinanciera> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
