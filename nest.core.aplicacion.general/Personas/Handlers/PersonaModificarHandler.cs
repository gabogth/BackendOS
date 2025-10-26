using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Personas.Commands;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Handlers
{
    public class PersonaModificarHandler : IRequestHandler<PersonaModificarCommand, Persona>
    {
        private readonly IPersonaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PersonaModificarHandler> logger;
        public PersonaModificarHandler(IPersonaRepository repository, IMapper mapper, ILogger<PersonaModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<Persona> Handle(PersonaModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = this.mapper.Map<Persona>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
