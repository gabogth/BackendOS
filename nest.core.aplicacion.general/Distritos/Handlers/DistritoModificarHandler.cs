using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Distritos.Commands;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Handlers
{
    public class DistritoModificarHandler : IRequestHandler<DistritoModificarCommand, Distrito>
    {
        private readonly IDistritoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DistritoModificarHandler> logger;
        public DistritoModificarHandler(IDistritoRepository repository, IMapper mapper, ILogger<DistritoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<Distrito> Handle(DistritoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = this.mapper.Map<Distrito>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
