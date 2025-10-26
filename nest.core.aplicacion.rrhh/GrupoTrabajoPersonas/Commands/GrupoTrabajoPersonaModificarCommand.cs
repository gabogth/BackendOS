using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;

public record GrupoTrabajoPersonaModificarCommand(
    long Id,
    int EmpresaId,
    long GrupoTrabajoId,
    int PersonaId,
    bool EsLider
) : IRequest<GrupoTrabajoPersona>, ICommandBase;
