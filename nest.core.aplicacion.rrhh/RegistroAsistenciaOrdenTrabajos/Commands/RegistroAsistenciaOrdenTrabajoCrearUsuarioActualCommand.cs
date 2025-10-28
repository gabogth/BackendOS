using MediatR;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands
{
    public record RegistroAsistenciaOrdenTrabajoCrearUsuarioActualCommand(
        decimal? Latitud,
        decimal? Longitud,
        long AdjuntoId
    ) : IRequest<RegistroAsistencia>;
}
