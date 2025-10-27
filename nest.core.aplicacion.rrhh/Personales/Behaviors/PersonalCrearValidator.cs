using FluentValidation;
using nest.core.aplicacion.rrhh.Personales.Commands;

namespace nest.core.aplicacion.rrhh.Personales.Behaviors;

public class PersonalCrearValidator : AbstractValidator<PersonalCrearCommand>
{
    public PersonalCrearValidator()
    {
        Include(new PersonalGenericValidator<PersonalCrearCommand>());
    }
}
