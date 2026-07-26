using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Handlers
{
    public class OrdenTrabajoHorarioCrearRangoHandler : IRequestHandler<OrdenTrabajoHorarioCrearRangoCommand, OrdenTrabajoHorario[]>
    {
        private readonly IOrdenTrabajoHorarioRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoHorarioCrearRangoHandler> logger;

        public OrdenTrabajoHorarioCrearRangoHandler(IOrdenTrabajoHorarioRepository repository, IMapper mapper, ILogger<OrdenTrabajoHorarioCrearRangoHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoHorario[]> Handle(OrdenTrabajoHorarioCrearRangoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<OrdenTrabajoHorario> entries = new List<OrdenTrabajoHorario>();
                foreach (var item in request.AsignacionFechas)
                {
                    var entry = mapper.Map<OrdenTrabajoHorario>(request);
                    entry.HorarioCabeceraId = item.HorarioCabeceraId;
                    entry.Fecha = item.Fecha;
                    entries.Add(entry);
                }
                return await repository.Agregar(entries.ToArray());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
