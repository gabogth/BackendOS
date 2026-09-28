using MediatR;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands
{
    public record RegistroAsistenciaOrdenTrabajoRegularizarModificarCommand(
        long RegistroAsistenciaId,
        string? Observacion,
        long? OrdenTrabajoId,
        DateTime? Fecha,
        DateOnly? FechaJornal,
        HorarioDetalleEventoTipoEnum EventoTipo
    ) : IRequest<RegistroAsistencia>;
}
