using FluentValidation;
using nest.core.aplicacion.mantto.Labores.Commands;

namespace nest.core.aplicacion.mantto.Labores.Behaviors
{
    public class LaborCrearValidator : AbstractValidator<LaborCrearCommand>
    {
        public LaborCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre debe tener como máximo 150 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto debe tener como máximo 50 caracteres.");
        }
    }
}
