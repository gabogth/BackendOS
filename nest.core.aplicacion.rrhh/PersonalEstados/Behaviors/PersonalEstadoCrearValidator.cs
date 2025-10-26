using FluentValidation;
using nest.core.aplicacion.rrhh.PersonalEstados.Commands;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Behaviors;

public class PersonalEstadoCrearValidator : AbstractValidator<PersonalEstadoCrearCommand>
{
    public PersonalEstadoCrearValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");
    }
}
