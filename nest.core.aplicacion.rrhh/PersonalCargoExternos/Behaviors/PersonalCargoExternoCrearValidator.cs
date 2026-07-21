using FluentValidation;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Behaviors;

public class PersonalCargoExternoCrearValidator : AbstractValidator<PersonalCargoExternoCrearCommand>
{
    public PersonalCargoExternoCrearValidator()
    {
        Include(new PersonalCargoExternoGenericValidator<PersonalCargoExternoCrearCommand>());
    }
}
