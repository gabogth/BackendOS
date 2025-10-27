using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.UsuarioEmpresas.Queries;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Handlers
{
    public sealed class ObtenerSeleccionadoHandler : IRequestHandler<ObtenerSeleccionadoQuery, UsuarioEmpresa?>
    {
        private readonly IUsuarioEmpresaRepository repository;
        private readonly ILogger<ObtenerSeleccionadoHandler> logger;

        public ObtenerSeleccionadoHandler(IUsuarioEmpresaRepository repository, ILogger<ObtenerSeleccionadoHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<UsuarioEmpresa?> Handle(ObtenerSeleccionadoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerSeleccionado(request.UsuarioId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener la empresa seleccionada para el usuario {Usuario}", request.UsuarioId);
                throw;
            }
        }
    }
}
