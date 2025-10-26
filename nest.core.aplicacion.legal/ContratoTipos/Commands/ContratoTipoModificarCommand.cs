using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Legal.ContratoTipoEntities;

namespace nest.core.aplicacion.legal.ContratoTipos.Commands
{
    public sealed record ContratoTipoModificarCommand(
        byte Id,
        string Nombre,
        string Detalle
    ) : IRequest<ContratoTipo>, ICommandBase;
}
