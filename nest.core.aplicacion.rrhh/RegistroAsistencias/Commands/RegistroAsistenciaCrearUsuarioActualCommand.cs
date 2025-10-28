using MediatR;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Commands
{
    public record RegistroAsistenciaCrearUsuarioActualCommand(
        decimal? Latitud,
        decimal? Longitud
    ) : IRequest<RegistroAsistencia>;
}
