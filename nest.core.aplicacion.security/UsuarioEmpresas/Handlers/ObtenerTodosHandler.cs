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
    public sealed class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<UsuarioEmpresa>>
    {
        private readonly IUsuarioEmpresaRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IUsuarioEmpresaRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<UsuarioEmpresa>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las relaciones usuario-empresa");
                throw;
            }
        }
    }
}
