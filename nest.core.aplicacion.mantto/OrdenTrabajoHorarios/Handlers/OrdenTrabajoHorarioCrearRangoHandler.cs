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
                List<OrdenTrabajoHorario> existentes = new List<OrdenTrabajoHorario>();

                if (request.AsignacionFechas == null || request.AsignacionFechas.Count == 0)
                    throw new Exception("SIN REGISTROS EN EL BODY");
                List<long> idsUpdate = request.AsignacionFechas.Where(x => x.Id > 0).Select(x => x.Id).ToList();
                if(idsUpdate.Count > 0)
                    existentes = await repository.ObtenerPorIds(idsUpdate);

                foreach (var item in request.AsignacionFechas)
                {
                    var entry = mapper.Map<OrdenTrabajoHorario>(request);
                    entry.HorarioCabeceraId = item.HorarioCabeceraId;
                    entry.Fecha = item.Fecha;
                    entries.Add(entry);
                }
                return await repository.Merge(existentes.ToArray(), entries.ToArray());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
