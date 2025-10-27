using FluentValidation;
using nest.core.aplicacion.general.Personas.Commands;

namespace nest.core.aplicacion.general.Personas.Behaviors
{
    public class PersonaModificarValidator : AbstractValidator<PersonaModificarCommand>
    {
        public PersonaModificarValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id es requerido.")
                .GreaterThan(0).WithMessage("Id debe ser mayor a 0.");
            Include(new PersonaGenericValidator<PersonaModificarCommand>());
        }
    }
}
