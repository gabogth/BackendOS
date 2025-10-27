using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands
{
    public interface IEstructuraOrganizacionalGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string Descripcion { get; }
        string NombreCorto { get; }
        int? ParentId { get; }
        int EstructuraOrganizacionalTipoId { get; }
        bool Estado { get; }
        bool Final { get; }
    }
}
