using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.Provincias.Commands
{
    public sealed record ProvinciaEliminarCommand(int Id) : IRequest<Unit>, ICommandBase;
}
