using FluentValidation;
using nest.core.aplicacion.general.DocumentoTipos.Commands;

namespace nest.core.aplicacion.general.DocumentoTipos.Behaviors
{
    public sealed class DocumentoTipoCrearValidator : AbstractValidator<DocumentoTipoCrearCommand>
    {
        public DocumentoTipoCrearValidator()
        {
            Include(new DocumentoTipoGenericValidator<DocumentoTipoCrearCommand>());
        }
    }
}
