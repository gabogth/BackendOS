using FluentValidation;
using nest.core.aplicacion.general.DocumentoTipos.Commands;

namespace nest.core.aplicacion.general.DocumentoTipos.Behaviors
{
    public sealed class DocumentoTipoCrearValidator : AbstractValidator<DocumentoTipoCrearCommand>
    {
        public DocumentoTipoCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no puede exceder los 150 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no puede exceder los 50 caracteres.");

            RuleFor(x => x.CodigoEstatal)
                .NotEmpty().WithMessage("El código estatal es requerido.")
                .MaximumLength(50).WithMessage("El código estatal no puede exceder los 50 caracteres.");
        }
    }
}
