using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.PaisEntities;

namespace nest.core.aplicacion.general.Paises.Commands
{
    public interface IPaisGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string CodigoIso { get; }
        string CodigoTelefono { get; }
    }
}
