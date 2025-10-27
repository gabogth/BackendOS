using FluentValidation;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Commands;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Behaviors
{
    public class AdjuntoConfigProviderModificarValidator : AbstractValidator<AdjuntoConfigProviderModificarCommand>
    {
        public AdjuntoConfigProviderModificarValidator()
        {
            RuleFor(x => x.Id)
                .IsInEnum().WithMessage("El identificador es inválido.");
            Include(new AdjuntoConfigProviderGenericValidator<AdjuntoConfigProviderModificarCommand>());
        }
    }
}
