using FluentValidation;
using nest.core.aplicacion.rrhh.Cargos.Commands;

namespace nest.core.aplicacion.rrhh.Cargos.Behaviors;

public class CargoEliminarValidator : AbstractValidator<CargoEliminarCommand>
{
    public CargoEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
