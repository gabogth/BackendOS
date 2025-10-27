using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.UsuarioEmpresas.Commands;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Handlers
{
    public sealed class UsuarioEmpresaSeleccionarHandler : IRequestHandler<UsuarioEmpresaSeleccionarCommand, Unit>
    {
        private readonly IUsuarioEmpresaRepository repository;
        private readonly ILogger<UsuarioEmpresaSeleccionarHandler> logger;

        public UsuarioEmpresaSeleccionarHandler(IUsuarioEmpresaRepository repository, ILogger<UsuarioEmpresaSeleccionarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UsuarioEmpresaSeleccionarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Seleccionar(request.UsuarioId, request.EmpresaId);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al seleccionar la empresa {Empresa} para el usuario {Usuario}", request.EmpresaId, request.UsuarioId);
                throw;
            }
        }
    }
}
