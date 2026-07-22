using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Horarios.Queries;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.aplicacion.rrhh.Horarios.Handlers
{
    internal class ObtenerHorariosPorFiltroDataSourceHandler : IRequestHandler<ObtenerHorariosPorFiltroDataSourceQuery, LoadResult>
    {
        private readonly IHorarioRepository repository;
        private readonly ILogger<ObtenerHorariosPorFiltroDataSourceHandler> logger;

        public ObtenerHorariosPorFiltroDataSourceHandler(IHorarioRepository repository, ILogger<ObtenerHorariosPorFiltroDataSourceHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<LoadResult> Handle(ObtenerHorariosPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerFilter(request.options, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los horarios por filtro datasource");
                throw;
            }
        }
    }
}
