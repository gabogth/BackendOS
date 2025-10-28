using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Commands
{
    public interface IRegistroAsistenciaGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        int PersonalId { get; }
        DateTime Fecha { get; }
        decimal? Latitud { get; }
        decimal? Longitud { get; }
    }
}
