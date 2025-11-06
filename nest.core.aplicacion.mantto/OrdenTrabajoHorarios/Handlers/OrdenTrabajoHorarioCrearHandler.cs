using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Handlers
{
    public class OrdenTrabajoHorarioCrearHandler : IRequestHandler<OrdenTrabajoHorarioCrearCommand, OrdenTrabajoHorario>
    {
        private readonly IOrdenTrabajoHorarioRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoHorarioCrearHandler> logger;

        public OrdenTrabajoHorarioCrearHandler(IOrdenTrabajoHorarioRepository repository, IMapper mapper, ILogger<OrdenTrabajoHorarioCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoHorario> Handle(OrdenTrabajoHorarioCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoHorario>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
