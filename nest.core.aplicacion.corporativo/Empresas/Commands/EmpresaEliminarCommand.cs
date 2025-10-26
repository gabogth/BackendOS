using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.corporativo.Empresas.Commands
{
    public sealed record EmpresaEliminarCommand(
        int Id
    ) : IRequest<bool>, ICommandBase;
}
