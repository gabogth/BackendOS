using FluentValidation;
using nest.core.aplicacion.general.Paises.Commands;

namespace nest.core.aplicacion.general.Paises.Behaviors
{
    public class PaisModificarValidator : AbstractValidator<PaisModificarCommand>
    {
        public PaisModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a cero.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no debe superar los 150 caracteres.");

            RuleFor(x => x.CodigoIso)
                .NotEmpty().WithMessage("El código ISO es requerido.")
                .MaximumLength(5).WithMessage("El código ISO no debe superar los 5 caracteres.");

            RuleFor(x => x.CodigoTelefono)
                .NotEmpty().WithMessage("El código telefónico es requerido.")
                .MaximumLength(10).WithMessage("El código telefónico no debe superar los 10 caracteres.");
        }
    }
}
