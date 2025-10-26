using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.legal.ContratoTipos.Commands;
using nest.core.dominio.Legal.ContratoTipoEntities;

namespace nest.core.aplicacion.legal.ContratoTipos.Handlers
{
    public class ContratoTipoModificarHandler : IRequestHandler<ContratoTipoModificarCommand, ContratoTipo>
    {
        private readonly IContratoTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<ContratoTipoModificarHandler> logger;

        public ContratoTipoModificarHandler(IContratoTipoRepository repository, IMapper mapper, ILogger<ContratoTipoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<ContratoTipo> Handle(ContratoTipoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<ContratoTipo>(request);
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
