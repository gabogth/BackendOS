using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.Horarios.Commands
{
    public record HorarioDetalleCommand(
        long? Id,
        int EmpresaId,
        int HorarioCabeceraId,
        DayOfWeek DiaSemana,
        IReadOnlyCollection<HorarioDetalleEventoCommand> Eventos
    ) : ICommandBase;
}
