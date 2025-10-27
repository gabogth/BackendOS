using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands
{
    public interface IGrupoTrabajoPersonaGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        long GrupoTrabajoId { get; }
        int PersonaId { get; }
        bool EsLider { get; }
    }
}
