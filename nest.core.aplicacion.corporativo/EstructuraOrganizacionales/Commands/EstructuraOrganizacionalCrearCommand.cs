using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands
{
    public sealed record EstructuraOrganizacionalCrearCommand(
        int EmpresaId,
        string Nombre,
        string Descripcion,
        string NombreCorto,
        int? ParentId,
        int EstructuraOrganizacionalTipoId,
        bool Estado,
        bool Final
    ) : IRequest<EstructuraOrganizacional>, ICommandBase;
}
