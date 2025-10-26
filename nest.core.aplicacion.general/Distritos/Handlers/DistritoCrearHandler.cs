using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Distritos.Commands;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Handlers
{
    public class DistritoCrearHandler : IRequestHandler<DistritoCrearCommand, Distrito>
    {
        private readonly IDistritoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DistritoCrearCommand> logger;
        public DistritoCrearHandler(IDistritoRepository repository, IMapper mapper, ILogger<DistritoCrearCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<Distrito> Handle(DistritoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = this.mapper.Map<Distrito>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
