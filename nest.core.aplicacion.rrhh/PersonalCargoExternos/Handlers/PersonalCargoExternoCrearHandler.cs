using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Handlers;

public class PersonalCargoExternoCrearHandler : IRequestHandler<PersonalCargoExternoCrearCommand, PersonalCargoExterno>
{
    private readonly IPersonalCargoExternoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<PersonalCargoExternoCrearHandler> logger;

    public PersonalCargoExternoCrearHandler(IPersonalCargoExternoRepository repository, IMapper mapper, ILogger<PersonalCargoExternoCrearHandler> logger)
    { this.repository = repository; this.mapper = mapper; this.logger = logger; }

    public async Task<PersonalCargoExterno> Handle(PersonalCargoExternoCrearCommand request, CancellationToken cancellationToken)
    {
        try { return await repository.Agregar(mapper.Map<PersonalCargoExterno>(request)); }
        catch (Exception ex) { logger.LogError(ex, "Error al crear el cargo externo del personal {PersonalId}", request.PersonalId); throw; }
    }
}
