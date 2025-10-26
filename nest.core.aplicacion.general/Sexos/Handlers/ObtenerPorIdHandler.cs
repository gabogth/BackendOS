using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Sexos.Queries;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Sexos.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, Sexo>
    {
        private readonly ISexoRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(ISexoRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Sexo> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
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
