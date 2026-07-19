using MediatR;
using nest.core.aplicacion.iclock.Marcaciones.Commands;

namespace nest.core.aplicacion.iclock.Marcaciones.Handlers
{
    public class RecibirMarcacionesHandler : IRequestHandler<RecibirMarcacionesCommand, Unit>
    {
        public Task<Unit> Handle(RecibirMarcacionesCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
