using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands
{
    public interface IDocumentoIdentidadTipoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
    }
}
