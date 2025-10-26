using FluentValidation;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Commands;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Behaviors
{
    public class AdjuntoConfigProviderEliminarValidator : AbstractValidator<AdjuntoConfigProviderEliminarCommand>
    {
        public AdjuntoConfigProviderEliminarValidator()
        {
            RuleFor(x => x.Id)
                .IsInEnum().WithMessage("El identificador es inválido.");
        }
    }
}
