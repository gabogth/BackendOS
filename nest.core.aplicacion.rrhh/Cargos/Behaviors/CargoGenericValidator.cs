using FluentValidation;
using nest.core.aplicacion.rrhh.Cargos.Commands;

namespace nest.core.aplicacion.rrhh.Cargos.Behaviors
{
    public class CargoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICargoGenericCommand
    {
        public CargoGenericValidator()
        {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(200).WithMessage("El nombre no puede exceder los 200 caracteres.");

        RuleFor(x => x.Estado)
            .NotNull().WithMessage("El estado es obligatorio.");
        }
    }
}
