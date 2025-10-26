using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Personas.Commands;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Handlers
{
    public class PersonaEliminarHandler : IRequestHandler<PersonaEliminarCommand, bool>
    {
        private readonly IPersonaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PersonaEliminarHandler> logger;
        public PersonaEliminarHandler(IPersonaRepository repository, IMapper mapper, ILogger<PersonaEliminarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<bool> Handle(PersonaEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
