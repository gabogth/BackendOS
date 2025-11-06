using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands
{
    public sealed record OrdenTrabajoHorarioCrearCommand(
        int EmpresaId,
        long OrdenTrabajoCabeceraId,
        int PersonalId,
        DateOnly Fecha,
        long HorarioCabeceraId
    ) : IRequest<OrdenTrabajoHorario>, IOrdenTrabajoHorarioGenericCommand;
}
