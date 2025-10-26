using FluentValidation;
using nest.core.aplicacion.security.Modulos.Commands;

namespace nest.core.aplicacion.security.Modulos.Behaviors;

public class ModuloEliminarValidator : AbstractValidator<ModuloEliminarCommand>
{
    public ModuloEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
