using MediatR;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Commands
{
    public record RegistroAsistenciaCrearServerDtCommand(
        int EmpresaId,
        int PersonalId,
        decimal? Latitud,
        decimal? Longitud
    ) : IRequest<RegistroAsistencia>;
}
