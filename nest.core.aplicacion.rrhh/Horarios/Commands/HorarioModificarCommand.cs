using MediatR;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.aplicacion.rrhh.Horarios.Commands
{
    public record HorarioModificarCommand(
        int Id,
        int EmpresaId,
        string Nombre,
        string Descripcion,
        bool Activo,
        int MinutosDescanso,
        int MinutosTraslado,
        IReadOnlyCollection<HorarioDetalleCommand> Detalles
    ) : IRequest<HorarioCabecera>, IHorarioGenericCommand;
}
