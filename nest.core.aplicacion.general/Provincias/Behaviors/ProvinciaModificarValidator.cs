using FluentValidation;
using nest.core.aplicacion.general.Provincias.Commands;

namespace nest.core.aplicacion.general.Provincias.Behaviors
{
    public class ProvinciaModificarValidator : AbstractValidator<ProvinciaModificarCommand>
    {
        public ProvinciaModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a cero.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no debe superar los 150 caracteres.");

            RuleFor(x => x.DepartamentoId)
                .GreaterThan(0).WithMessage("El departamento es requerido.");
        }
    }
}
