using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Commands
{
    public interface IOrigenFinancieroGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        string Naturaleza { get; }
        bool Activo { get; }
    }
}
