using MediatR;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Commands
{
    public record RegistroAsistenciaTerminalZKTecoCrearCommand(
        string SerialNumber,
        int DocumentoTipo,
        string DocumentoNumero,
        DateTime Fecha
    ) : IRequest<RegistroAsistencia>;
}
