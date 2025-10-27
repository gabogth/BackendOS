using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.FinancieroCabeceras.Queries;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, FinancieroCabecera>
    {
        private readonly IFinancieroCabeceraRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IFinancieroCabeceraRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<FinancieroCabecera> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await repository.ObtenerPorId(request.Id);
                return entity;
            }
            catch (RegistroNoEncontradoException<FinancieroCabecera>)
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
