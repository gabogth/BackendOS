using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Commands
{
    public record DistritoCrearCommand (
        string Nombre,
        int ProvinciaId
    ) : IRequest<Distrito>, IDistritoGenericCommand;
}
