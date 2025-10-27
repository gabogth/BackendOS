using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.AdjuntoTipoEntities;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Commands
{
    public interface IPersonaAdjuntoGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        int PersonaId { get; }
        long AdjuntoId { get; }
        AdjuntoTipoEnum AdjuntoTipoId { get; }
        bool EsFotoPrincipal { get; }
    }
}
