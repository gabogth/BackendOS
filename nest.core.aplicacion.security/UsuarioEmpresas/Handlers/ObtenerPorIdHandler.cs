using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.UsuarioEmpresas.Queries;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Handlers
{
    public sealed class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, UsuarioEmpresa?>
    {
        private readonly IUsuarioEmpresaRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IUsuarioEmpresaRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<UsuarioEmpresa?> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener la relación usuario-empresa {Id}", request.Id);
                throw;
            }
        }
    }
}
