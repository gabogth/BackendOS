using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands
{
    public sealed record EstructuraOrganizacionalTipoModificarCommand(
        int Id,
        string Nombre,
        string NombreCorto,
        string Descripcion,
        bool Estado
    ) : IRequest<EstructuraOrganizacionalTipo>, ICommandBase;
}
