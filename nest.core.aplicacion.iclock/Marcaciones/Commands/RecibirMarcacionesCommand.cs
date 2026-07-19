using MediatR;

namespace nest.core.aplicacion.iclock.Marcaciones.Commands
{
    public record RecibirMarcacionesCommand(
        int DocumentoTipo,
        string DocumentoNumero
    ) : IRequest<Unit>;
}
