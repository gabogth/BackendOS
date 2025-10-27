using FluentValidation;
using nest.core.aplicacion.security.Formularios.Commands;

namespace nest.core.aplicacion.security.Formularios.Behaviors;

public class FormularioModificarValidator : AbstractValidator<FormularioModificarCommand>
{
    public FormularioModificarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
            Include(new FormularioGenericValidator<FormularioModificarCommand>());
    }
}
