using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.Moneda.Commands
{
    public interface IMonedaGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        string Prefix { get; }
        string Sufix { get; }
        string Simbolo { get; }
    }
}
