using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Handlers
{
    public class UbicacionActivoModificarHandler : IRequestHandler<UbicacionActivoModificarCommand, UbicacionActivo>
    {
        private readonly IUbicacionActivoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<UbicacionActivoModificarHandler> logger;

        public UbicacionActivoModificarHandler(IUbicacionActivoRepository repository, IMapper mapper, ILogger<UbicacionActivoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<UbicacionActivo> Handle(UbicacionActivoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<UbicacionActivo>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al actualizar la ubicación del activo {UbicacionActivoId}", request.Id);
                throw;
            }
        }
    }
}
