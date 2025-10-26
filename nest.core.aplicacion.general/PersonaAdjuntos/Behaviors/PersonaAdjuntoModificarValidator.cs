using FluentValidation;
using nest.core.aplicacion.general.PersonaAdjuntos.Commands;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Behaviors
{
    public sealed class PersonaAdjuntoModificarValidator : AbstractValidator<PersonaAdjuntoModificarCommand>
    {
        public PersonaAdjuntoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es requerida.");

            RuleFor(x => x.PersonaId)
                .GreaterThan(0).WithMessage("La persona es requerida.");

            RuleFor(x => x.AdjuntoId)
                .GreaterThan(0).WithMessage("El adjunto es requerido.");

            RuleFor(x => x.AdjuntoTipoId)
                .IsInEnum().WithMessage("El tipo de adjunto es inválido.");
        }
    }
}
