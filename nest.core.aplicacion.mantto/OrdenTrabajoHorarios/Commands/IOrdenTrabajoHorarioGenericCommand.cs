using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands
{
    public interface IOrdenTrabajoHorarioGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        long OrdenTrabajoCabeceraId { get; }
        int PersonalId { get; }
        DateOnly Fecha { get; }
        long HorarioCabeceraId { get; }
    }
}
