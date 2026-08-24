using MediatR;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands
{
    public record RegistroAsistenciaOrdenTrabajoRegularizarCrearCommand(
        int EmpresaId,
        int PersonalId,
        decimal? Latitud,
        decimal? Longitud,
        long AdjuntoId,
        string? Observacion,
        long? OrdenTrabajoId,
        string? Obseracion,
        HorarioDetalleEventoTipoEnum EventoTipo,
        RegistroAsistenciaTipoRegularizacionId TipoRegularizacion
    ) : IRequest<RegistroAsistencia>;
}
