using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Departamentos.Queries;
using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.Departamentos.Handlers
{
    public class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<Departamento>>
    {
        private readonly IDepartamentoRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IDepartamentoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<Departamento>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
