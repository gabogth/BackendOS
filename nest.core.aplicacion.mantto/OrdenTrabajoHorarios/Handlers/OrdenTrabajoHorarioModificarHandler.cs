using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Handlers
{
    public class OrdenTrabajoHorarioModificarHandler : IRequestHandler<OrdenTrabajoHorarioModificarCommand, OrdenTrabajoHorario>
    {
        private readonly IOrdenTrabajoHorarioRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenTrabajoHorarioModificarHandler> logger;

        public OrdenTrabajoHorarioModificarHandler(IOrdenTrabajoHorarioRepository repository, IMapper mapper, ILogger<OrdenTrabajoHorarioModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoHorario> Handle(OrdenTrabajoHorarioModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenTrabajoHorario>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
