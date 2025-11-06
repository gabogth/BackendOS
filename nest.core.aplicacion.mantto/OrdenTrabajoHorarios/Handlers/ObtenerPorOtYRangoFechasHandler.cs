using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Handlers
{
    internal class ObtenerPorOtYRangoFechasHandler : IRequestHandler<ObtenerPorOtYRangoFechasQuery, List<OrdenTrabajoHorario>>
    {
        private readonly IOrdenTrabajoHorarioRepository repository;
        private readonly ILogger<ObtenerPorOtYRangoFechasHandler> logger;

        public ObtenerPorOtYRangoFechasHandler(IOrdenTrabajoHorarioRepository repository, ILogger<ObtenerPorOtYRangoFechasHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoHorario>> Handle(ObtenerPorOtYRangoFechasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorOtYRangoFechas(request.OrdenTrabajoCabeceraId, request.Inicio, request.Fin);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
