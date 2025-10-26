using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.LicenciasConducir.Commands
{
    public sealed record LicenciaConducirEliminarCommand(
        byte Id
    ) : IRequest<bool>, ICommandBase;
}
