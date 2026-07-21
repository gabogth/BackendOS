using FluentValidation;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Behaviors;

public class PersonalCargoExternoEliminarValidator : AbstractValidator<PersonalCargoExternoEliminarCommand>
{
    public PersonalCargoExternoEliminarValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
