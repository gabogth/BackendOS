using FluentValidation;
using nest.core.aplicacion.general.Distritos.Commands;

namespace nest.core.aplicacion.general.Distritos.Behaviors
{
    public class PersonaModificarValidator : AbstractValidator<PersonaModificarCommand>
    {
        public PersonaModificarValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id es requerido.");
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("Nombre es requerido.");
            RuleFor(x => x.ProvinciaId)
                .NotEmpty().WithMessage("Provincia es requerida.");
        }
    }
}
