using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipos.Commands
{
    public sealed record AdjuntoTipoEliminarCommand(AdjuntoTipoEnum Id) : IRequest<Unit>, ICommandBase;
}
