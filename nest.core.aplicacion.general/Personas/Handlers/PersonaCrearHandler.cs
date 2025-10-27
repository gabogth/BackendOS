 using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Personas.Commands;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Handlers
{
    public class PersonaCrearHandler : IRequestHandler<PersonaCrearCommand, Persona>
    {
        private readonly IPersonaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PersonaCrearCommand> logger;
        public PersonaCrearHandler(IPersonaRepository repository, IMapper mapper, ILogger<PersonaCrearCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<Persona> Handle(PersonaCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = this.mapper.Map<Persona>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
