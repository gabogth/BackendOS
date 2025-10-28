using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands
{
    public interface IRegistroAsistenciaAdjuntoGenericCommand : ICommandBase
    {
        long RegistroAsistenciaId { get; }
        int EmpresaId { get; }
        long AdjuntoId { get; }
    }
}
