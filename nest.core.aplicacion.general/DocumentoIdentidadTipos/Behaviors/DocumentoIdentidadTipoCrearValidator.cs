using FluentValidation;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Behaviors
{
    public sealed class DocumentoIdentidadTipoCrearValidator : AbstractValidator<DocumentoIdentidadTipoCrearCommand>
    {
        public DocumentoIdentidadTipoCrearValidator()
        {
            Include(new DocumentoIdentidadTipoGenericValidator<DocumentoIdentidadTipoCrearCommand>());
        }
    }
}
