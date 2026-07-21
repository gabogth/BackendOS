using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Handlers;

public class PersonalCargoExternoModificarHandler : IRequestHandler<PersonalCargoExternoModificarCommand, PersonalCargoExterno>
{
    private readonly IPersonalCargoExternoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<PersonalCargoExternoModificarHandler> logger;

    public PersonalCargoExternoModificarHandler(IPersonalCargoExternoRepository repository, IMapper mapper, ILogger<PersonalCargoExternoModificarHandler> logger)
    { this.repository = repository; this.mapper = mapper; this.logger = logger; }

    public async Task<PersonalCargoExterno> Handle(PersonalCargoExternoModificarCommand request, CancellationToken cancellationToken)
    {
        try { return await repository.Modificar(mapper.Map<PersonalCargoExterno>(request)); }
        catch (Exception ex) { logger.LogError(ex, "Error al modificar el cargo externo del personal {Id}", request.Id); throw; }
    }
}
