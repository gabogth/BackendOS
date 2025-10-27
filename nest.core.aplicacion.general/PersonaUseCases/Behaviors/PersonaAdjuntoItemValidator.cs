using FluentValidation;
using nest.core.aplicacion.general.PersonaUseCases.Commands;

namespace nest.core.aplicacion.general.PersonaUseCases.Behaviors
{
    public class PersonaAdjuntoItemValidator : AbstractValidator<PersonaAdjuntoItemCommand>
    {
        public PersonaAdjuntoItemValidator()
        {
            RuleFor(x => x.AdjuntoId)
                .GreaterThan(0).WithMessage("El identificador del adjunto es requerido.");
            RuleFor(x => x.AdjuntoTipoId)
                .IsInEnum().WithMessage("El tipo de adjunto es inválido.");
        }
    }
}
