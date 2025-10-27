using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Commands
{
    public record GrupoTrabajoPersonaCommand(
        long? Id,
        long? GrupoTrabajoId,
        int PersonaId,
        bool EsLider,
        int EmpresaId
    ) : ICommandBase;
}
