using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Departamentos.Commands;
using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.Departamentos.Handlers
{
    public class DepartamentoEliminarHandler : IRequestHandler<DepartamentoEliminarCommand, Unit>
    {
        private readonly IDepartamentoRepository repository;
        private readonly ILogger<DepartamentoEliminarHandler> logger;

        public DepartamentoEliminarHandler(IDepartamentoRepository repository, ILogger<DepartamentoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(DepartamentoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
