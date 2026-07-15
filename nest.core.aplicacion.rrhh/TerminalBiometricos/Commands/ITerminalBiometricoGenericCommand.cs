using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Commands
{
    public interface ITerminalBiometricoGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string SN { get; }
    }
}
