using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.Horarios.Commands
{
    public record HorarioDetalleEventoCommand(
        long? Id,
        int EmpresaId,
        long? HorarioDetalleId,
        HorarioDetalleEventoTipoEnum TipoEvento,
        TimeOnly Hora,
        int DiferenciaDia,
        int VentanaMin,
        int VentanaMax
    ) : ICommandBase;
}
