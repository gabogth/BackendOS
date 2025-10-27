using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.EntidadFinancieras.Commands;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;

namespace nest.core.aplicacion.finanzas.EntidadFinancieras.Handlers
{
    internal class EntidadFinancieraCrearHandler : IRequestHandler<EntidadFinancieraCrearCommand, EntidadFinanciera>
    {
        private readonly IEntidadFinancieraRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<EntidadFinancieraCrearHandler> logger;

        public EntidadFinancieraCrearHandler(IEntidadFinancieraRepository repository, IMapper mapper, ILogger<EntidadFinancieraCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<EntidadFinanciera> Handle(EntidadFinancieraCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<EntidadFinanciera>(request);
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
