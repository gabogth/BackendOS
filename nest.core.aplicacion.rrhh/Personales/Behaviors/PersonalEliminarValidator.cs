using FluentValidation;
using nest.core.aplicacion.rrhh.Personales.Commands;

namespace nest.core.aplicacion.rrhh.Personales.Behaviors;

public class PersonalEliminarValidator : AbstractValidator<PersonalEliminarCommand>
{
    public PersonalEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
