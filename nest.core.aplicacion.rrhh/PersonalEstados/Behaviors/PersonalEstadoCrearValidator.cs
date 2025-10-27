using FluentValidation;
using nest.core.aplicacion.rrhh.PersonalEstados.Commands;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Behaviors;

public class PersonalEstadoCrearValidator : AbstractValidator<PersonalEstadoCrearCommand>
{
    public PersonalEstadoCrearValidator()
    {
        Include(new PersonalEstadoGenericValidator<PersonalEstadoCrearCommand>());
    }
}
