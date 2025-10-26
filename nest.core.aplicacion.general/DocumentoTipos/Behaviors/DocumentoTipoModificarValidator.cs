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
