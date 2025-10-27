using FluentValidation;
using nest.core.aplicacion.general.DocumentoTipos.Commands;

namespace nest.core.aplicacion.general.DocumentoTipos.Behaviors
{
    public sealed class DocumentoTipoModificarValidator : AbstractValidator<DocumentoTipoModificarCommand>
    {
        public DocumentoTipoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new DocumentoTipoGenericValidator<DocumentoTipoModificarCommand>());
        }
    }
}
