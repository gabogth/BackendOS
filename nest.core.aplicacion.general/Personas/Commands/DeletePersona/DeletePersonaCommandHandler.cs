using System;
using MediatR;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Commands.DeletePersona
{
    public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand, Unit>
    {
        private readonly IPersonaRepository repository;

        public DeletePersonaCommandHandler(IPersonaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
    }
}
