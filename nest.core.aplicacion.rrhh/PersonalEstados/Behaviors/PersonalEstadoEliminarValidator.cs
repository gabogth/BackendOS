using FluentValidation;
using nest.core.aplicacion.rrhh.PersonalEstados.Commands;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Behaviors;

public class PersonalEstadoEliminarValidator : AbstractValidator<PersonalEstadoEliminarCommand>
{
    public PersonalEstadoEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan((byte)0).WithMessage("El identificador es obligatorio.");
    }
}
