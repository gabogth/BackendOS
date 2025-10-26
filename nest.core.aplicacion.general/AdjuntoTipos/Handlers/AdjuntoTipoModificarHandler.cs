using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.AdjuntoTipos.Commands;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipos.Handlers
{
    public class AdjuntoTipoModificarHandler : IRequestHandler<AdjuntoTipoModificarCommand, AdjuntoTipo>
    {
        private readonly IAdjuntoTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<AdjuntoTipoModificarHandler> logger;

        public AdjuntoTipoModificarHandler(IAdjuntoTipoRepository repository, IMapper mapper, ILogger<AdjuntoTipoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<AdjuntoTipo> Handle(AdjuntoTipoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<AdjuntoTipo>(request);
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
