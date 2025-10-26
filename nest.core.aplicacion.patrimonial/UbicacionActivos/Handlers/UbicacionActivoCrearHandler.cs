using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Handlers
{
    public class UbicacionActivoCrearHandler : IRequestHandler<UbicacionActivoCrearCommand, UbicacionActivo>
    {
        private readonly IUbicacionActivoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<UbicacionActivoCrearHandler> logger;

        public UbicacionActivoCrearHandler(IUbicacionActivoRepository repository, IMapper mapper, ILogger<UbicacionActivoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<UbicacionActivo> Handle(UbicacionActivoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<UbicacionActivo>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al registrar la ubicación del activo");
                throw;
            }
        }
    }
}
