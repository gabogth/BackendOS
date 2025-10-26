using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Handlers
{
    public class UbicacionTecnicaCrearHandler : IRequestHandler<UbicacionTecnicaCrearCommand, UbicacionTecnica>
    {
        private readonly IUbicacionTecnicaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<UbicacionTecnicaCrearHandler> logger;

        public UbicacionTecnicaCrearHandler(IUbicacionTecnicaRepository repository, IMapper mapper, ILogger<UbicacionTecnicaCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<UbicacionTecnica> Handle(UbicacionTecnicaCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<UbicacionTecnica>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al registrar la ubicación técnica");
                throw;
            }
        }
    }
}
