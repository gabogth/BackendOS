using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.UsuarioEmpresas.Commands;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Handlers
{
    public sealed class UsuarioEmpresaEliminarHandler : IRequestHandler<UsuarioEmpresaEliminarCommand, Unit>
    {
        private readonly IUsuarioEmpresaRepository repository;
        private readonly ILogger<UsuarioEmpresaEliminarHandler> logger;

        public UsuarioEmpresaEliminarHandler(IUsuarioEmpresaRepository repository, ILogger<UsuarioEmpresaEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UsuarioEmpresaEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await repository.ObtenerPorId(request.Id)
                    ?? throw new RegistroNoEncontradoException<UsuarioEmpresa>(request.Id);

                await repository.Eliminar(entity.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar la relación usuario-empresa {Id}", request.Id);
                throw;
            }
        }
    }
}
