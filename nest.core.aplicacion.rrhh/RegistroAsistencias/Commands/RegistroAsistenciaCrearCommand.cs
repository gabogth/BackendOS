using MediatR;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Commands
{
    public record RegistroAsistenciaCrearCommand(
        int EmpresaId,
        int PersonalId,
        DateTime Fecha,
        decimal? Latitud,
        decimal? Longitud
    ) : IRequest<RegistroAsistencia>, IRegistroAsistenciaGenericCommand;
}
