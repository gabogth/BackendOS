using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.Activos.Commands;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.aplicacion.patrimonial.Activos.Handlers
{
    public class ActivoCrearHandler : IRequestHandler<ActivoCrearCommand, Activo>
    {
        private readonly IActivoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<ActivoCrearHandler> logger;

        public ActivoCrearHandler(IActivoRepository repository, IMapper mapper, ILogger<ActivoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Activo> Handle(ActivoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Activo>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear el activo");
                throw;
            }
        }
    }
}
