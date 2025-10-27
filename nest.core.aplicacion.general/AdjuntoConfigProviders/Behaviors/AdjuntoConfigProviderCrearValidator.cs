using FluentValidation;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Commands;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Behaviors
{
    public class AdjuntoConfigProviderCrearValidator : AbstractValidator<AdjuntoConfigProviderCrearCommand>
    {
        public AdjuntoConfigProviderCrearValidator()
        {
            Include(new AdjuntoConfigProviderGenericValidator<AdjuntoConfigProviderCrearCommand>());
        }
    }
}
