using MediatR;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.iclock.Marcaciones.Commands
{
    public record RecibirMarcacionesCommand(
        int DocumentoTipo,
        string DocumentoNumero,
        string Device,
        DateTime Fecha
    ) : IRequest<RegistroAsistencia>;
}
