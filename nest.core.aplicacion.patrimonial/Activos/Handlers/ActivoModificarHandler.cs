using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.Activos.Commands;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.aplicacion.patrimonial.Activos.Handlers
{
    public class ActivoModificarHandler : IRequestHandler<ActivoModificarCommand, Activo>
    {
        private readonly IActivoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<ActivoModificarHandler> logger;

        public ActivoModificarHandler(IActivoRepository repository, IMapper mapper, ILogger<ActivoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Activo> Handle(ActivoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Activo>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar el activo {ActivoId}", request.Id);
                throw;
            }
        }
    }
}
