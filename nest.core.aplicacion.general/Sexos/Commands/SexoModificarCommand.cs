using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Sexos.Commands
{
    public sealed record SexoModificarCommand(
        byte Id,
        string Nombre,
        string NombreCorto
    ) : IRequest<Sexo>, ICommandBase;
}
