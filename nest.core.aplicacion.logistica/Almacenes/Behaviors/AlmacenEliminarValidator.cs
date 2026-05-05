using FluentValidation;
using nest.core.aplicacion.logistica.Almacenes.Commands;

namespace nest.core.aplicacion.rrhh.Cargos.Behaviors;

public class AlmacenEliminarValidator : AbstractValidator<AlmacenEliminarCommand>
{
    public AlmacenEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
