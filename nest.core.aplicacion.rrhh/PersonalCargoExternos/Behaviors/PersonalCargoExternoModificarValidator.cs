using FluentValidation;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Behaviors;

public class PersonalCargoExternoModificarValidator : AbstractValidator<PersonalCargoExternoModificarCommand>
{
    public PersonalCargoExternoModificarValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("El identificador es obligatorio.");
        Include(new PersonalCargoExternoGenericValidator<PersonalCargoExternoModificarCommand>());
    }
}
