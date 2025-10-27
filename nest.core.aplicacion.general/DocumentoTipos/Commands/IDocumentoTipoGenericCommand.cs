using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.DocumentoTipos.Commands
{
    public interface IDocumentoTipoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        string CodigoEstatal { get; }
    }
}
