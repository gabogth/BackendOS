using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.DocumentoTipos.Commands
{
    public sealed record DocumentoTipoCrearCommand(
        string Nombre,
        string NombreCorto,
        string CodigoEstatal
    ) : IRequest<DocumentoTipo>, ICommandBase;
}
