using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Commands
{
    public record DistritoModificarCommand(
        int Id,
        string Nombre,
        int ProvinciaId
    ) : IRequest<Distrito>, ICommandBase;
}
