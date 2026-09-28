using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities.Views;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Handlers
{
    internal class ObtenerPorOtYRangoFechasHandler : IRequestHandler<ObtenerPorOtYRangoFechasQuery, List<OrdenTrabajoHorarioView_PorOTRangoFechas>>
    {
        private readonly IOrdenTrabajoHorarioRepository repository;
        private readonly ILogger<ObtenerPorOtYRangoFechasHandler> logger;

        public ObtenerPorOtYRangoFechasHandler(IOrdenTrabajoHorarioRepository repository, ILogger<ObtenerPorOtYRangoFechasHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoHorarioView_PorOTRangoFechas>> Handle(ObtenerPorOtYRangoFechasQuery request, CancellationToken cancellationToken)
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
