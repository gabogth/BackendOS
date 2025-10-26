using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.Empresas.Commands;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.Empresas.Handlers
{
    public class EmpresaEliminarHandler : IRequestHandler<EmpresaEliminarCommand, bool>
    {
        private readonly IEmpresaRepository repository;
        private readonly ILogger<EmpresaEliminarHandler> logger;

        public EmpresaEliminarHandler(IEmpresaRepository repository, ILogger<EmpresaEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(EmpresaEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar la empresa");
                throw;
            }
        }
    }
}
