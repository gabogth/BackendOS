using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Commands
{
    public interface IPuntoFinancieroGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string NombreCorto { get; }
        bool Activo { get; }
    }
}
