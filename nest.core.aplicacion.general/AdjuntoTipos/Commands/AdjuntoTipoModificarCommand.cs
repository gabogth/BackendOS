using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipos.Commands
{
    public sealed record AdjuntoTipoModificarCommand(
        AdjuntoTipoEnum Id,
        string Nombre,
        string NombreCorto,
        bool Activo
    ) : IRequest<AdjuntoTipo>, ICommandBase;
}
