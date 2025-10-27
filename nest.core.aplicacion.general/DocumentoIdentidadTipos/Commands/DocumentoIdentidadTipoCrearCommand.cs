using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands
{
    public sealed record DocumentoIdentidadTipoCrearCommand(
        string Nombre,
        string NombreCorto
    ) : IRequest<DocumentoIdentidadTipo>, IDocumentoIdentidadTipoGenericCommand;
}
