using FluentValidation;
using nest.core.aplicacion.general.Distritos.Commands;

namespace nest.core.aplicacion.general.Distritos.Behaviors
{
    public class PersonaCrearValidator : AbstractValidator<PersonaCrearCommand>
    {
        public PersonaCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("Nombre es requerido.");
            RuleFor(x => x.ProvinciaId)
                .NotEmpty().WithMessage("Provincia es requerida.");
        }
    }
}
