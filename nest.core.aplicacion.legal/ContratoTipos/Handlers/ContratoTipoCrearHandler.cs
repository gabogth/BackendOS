using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.legal.ContratoTipos.Commands;
using nest.core.dominio.Legal.ContratoTipoEntities;

namespace nest.core.aplicacion.legal.ContratoTipos.Handlers
{
    public class ContratoTipoCrearHandler : IRequestHandler<ContratoTipoCrearCommand, ContratoTipo>
    {
        private readonly IContratoTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<ContratoTipoCrearHandler> logger;

        public ContratoTipoCrearHandler(IContratoTipoRepository repository, IMapper mapper, ILogger<ContratoTipoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<ContratoTipo> Handle(ContratoTipoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<ContratoTipo>(request);
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
