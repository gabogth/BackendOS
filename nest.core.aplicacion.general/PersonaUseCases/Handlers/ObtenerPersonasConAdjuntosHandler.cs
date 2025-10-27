using MediatR;
using nest.core.aplicacion.general.PersonaUseCases.Queries;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.PersonaUseCases.Handlers
{
    public class ObtenerPersonasConAdjuntosHandler : IRequestHandler<ObtenerPersonasConAdjuntosQuery, List<Persona>>
    {
        private readonly IPersonaAdjuntosUseCaseRepository repository;

        public ObtenerPersonasConAdjuntosHandler(IPersonaAdjuntosUseCaseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Persona>> Handle(ObtenerPersonasConAdjuntosQuery request, CancellationToken cancellationToken)
        {
            return await repository.ObtenerTodos();
        }
    }
}
