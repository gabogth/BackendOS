using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Queries;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, FinancieroDetalle>
    {
        private readonly IFinancieroDetalleRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IFinancieroDetalleRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<FinancieroDetalle> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (RegistroNoEncontradoException<FinancieroDetalle>)
            {
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
