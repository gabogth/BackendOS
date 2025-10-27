using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Commands
{
    public interface IGrupoTrabajoGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string NombreCorto { get; }
        bool Estado { get; }
        IReadOnlyCollection<GrupoTrabajoPersonaCommand> Personas { get; }
    }
}
