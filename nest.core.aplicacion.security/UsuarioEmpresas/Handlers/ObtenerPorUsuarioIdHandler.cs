using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.UsuarioEmpresas.Queries;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Handlers
{
    public sealed class ObtenerPorUsuarioIdHandler : IRequestHandler<ObtenerPorUsuarioIdQuery, List<UsuarioEmpresa>>
    {
        private readonly IUsuarioEmpresaRepository repository;
        private readonly ILogger<ObtenerPorUsuarioIdHandler> logger;

        public ObtenerPorUsuarioIdHandler(IUsuarioEmpresaRepository repository, ILogger<ObtenerPorUsuarioIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<UsuarioEmpresa>> Handle(ObtenerPorUsuarioIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.GetAllByUsuarioIdAsync(request.UsuarioId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las relaciones usuario-empresa para el usuario {Usuario}", request.UsuarioId);
                throw;
            }
        }
    }
}
