using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.iclock.Marcaciones.Commands;
using nest.core.aplicacion.iclock.Services.Interfaces;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.iclock.Marcaciones.Handlers
{
    public class RecibirMarcacionesHandler : IRequestHandler<RecibirMarcacionesCommand, RegistroAsistencia>
    {
        private readonly ILogger<RecibirMarcacionesHandler> logger;
        private readonly IMarcaRegistrar registrarMarcaService;
        public RecibirMarcacionesHandler(
            ILogger<RecibirMarcacionesHandler> logger,
            IMarcaRegistrar registrarMarcaService
            )
        {
            this.logger = logger;
            this.registrarMarcaService = registrarMarcaService;
        }
        public async Task<RegistroAsistencia> Handle(RecibirMarcacionesCommand request, CancellationToken cancellationToken)
        {
            return await registrarMarcaService.RegistrarMarca(request, cancellationToken);
        }
    }
}
