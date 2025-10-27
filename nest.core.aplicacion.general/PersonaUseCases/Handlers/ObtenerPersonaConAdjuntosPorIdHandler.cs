using MediatR;
using nest.core.aplicacion.general.PersonaUseCases.Queries;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.PersonaUseCases.Handlers
{
    public class ObtenerPersonaConAdjuntosPorIdHandler : IRequestHandler<ObtenerPersonaConAdjuntosPorIdQuery, Persona>
    {
        private readonly IPersonaAdjuntosUseCaseRepository repository;

        public ObtenerPersonaConAdjuntosPorIdHandler(IPersonaAdjuntosUseCaseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Persona> Handle(ObtenerPersonaConAdjuntosPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.ObtenerPorId(request.Id);
        }
    }
}
