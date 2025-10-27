using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands
{
    public interface IEstructuraOrganizacionalTipoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        string Descripcion { get; }
        bool Estado { get; }
    }
}
