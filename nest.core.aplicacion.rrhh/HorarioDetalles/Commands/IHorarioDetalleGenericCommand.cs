using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Commands
{
    public interface IHorarioDetalleGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        int HorarioCabeceraId { get; }
        DayOfWeek DiaSemana { get; }
    }
}
