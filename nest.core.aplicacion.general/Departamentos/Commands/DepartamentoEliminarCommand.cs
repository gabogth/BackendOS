using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.Departamentos.Commands
{
    public sealed record DepartamentoEliminarCommand(int Id) : IRequest<Unit>, ICommandBase;
}
