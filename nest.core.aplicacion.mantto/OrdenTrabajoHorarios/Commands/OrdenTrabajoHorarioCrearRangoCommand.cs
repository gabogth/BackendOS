using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands
{
    public sealed record OrdenTrabajoHorarioCrearRangoCommand(
        int EmpresaId,
        long OrdenTrabajoCabeceraId,
        int PersonalId,
        List<AsignacionFecha> AsignacionFechas
    ) : IRequest<OrdenTrabajoHorario[]>;

    public class AsignacionFecha
    {
        public DateOnly Fecha;
        public int HorarioCabeceraId;
    }
}
