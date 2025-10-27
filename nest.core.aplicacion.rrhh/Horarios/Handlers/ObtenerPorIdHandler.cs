using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Horarios.Queries;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.aplicacion.rrhh.Horarios.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, HorarioCabecera>
    {
        private readonly IHorarioRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IHorarioRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<HorarioCabecera> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener el horario {Id}", request.Id);
                throw;
            }
        }
    }
}
