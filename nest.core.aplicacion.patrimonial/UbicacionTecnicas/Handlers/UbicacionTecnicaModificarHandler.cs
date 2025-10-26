using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Handlers
{
    public class UbicacionTecnicaModificarHandler : IRequestHandler<UbicacionTecnicaModificarCommand, UbicacionTecnica>
    {
        private readonly IUbicacionTecnicaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<UbicacionTecnicaModificarHandler> logger;

        public UbicacionTecnicaModificarHandler(IUbicacionTecnicaRepository repository, IMapper mapper, ILogger<UbicacionTecnicaModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<UbicacionTecnica> Handle(UbicacionTecnicaModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<UbicacionTecnica>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al actualizar la ubicación técnica {UbicacionTecnicaId}", request.Id);
                throw;
            }
        }
    }
}
