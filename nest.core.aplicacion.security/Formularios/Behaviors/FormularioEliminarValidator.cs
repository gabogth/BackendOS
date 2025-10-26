using FluentValidation;
using nest.core.aplicacion.security.Formularios.Commands;

namespace nest.core.aplicacion.security.Formularios.Behaviors;

public class FormularioEliminarValidator : AbstractValidator<FormularioEliminarCommand>
{
    public FormularioEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
