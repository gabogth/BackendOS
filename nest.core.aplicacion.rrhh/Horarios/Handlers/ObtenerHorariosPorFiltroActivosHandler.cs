using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Horarios.Queries;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.aplicacion.rrhh.Horarios.Handlers
{
    internal class ObtenerHorariosPorFiltroActivosHandler : IRequestHandler<ObtenerHorariosPorFiltroActivosQuery, LoadResult>
    {
        private readonly IHorarioRepository repository;
        private readonly ILogger<ObtenerHorariosPorFiltroActivosHandler> logger;

        public ObtenerHorariosPorFiltroActivosHandler(IHorarioRepository repository, ILogger<ObtenerHorariosPorFiltroActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<LoadResult> Handle(ObtenerHorariosPorFiltroActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerFilterActivos(request.options, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los horarios activos por filtro datasource");
                throw;
            }
        }
    }
}
