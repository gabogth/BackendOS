using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.PaisEntities;

namespace nest.core.aplicacion.general.Paises.Commands
{
    public sealed record PaisModificarCommand(
        int Id,
        string Nombre,
        string CodigoIso,
        string CodigoTelefono
    ) : IRequest<Pais>, IPaisGenericCommand;
}
