using FluentValidation;
using nest.core.aplicacion.finanzas.Financiero.Commands;

namespace nest.core.aplicacion.finanzas.Financiero.Behaviors
{
    public class FinancieroModificarValidator : AbstractValidator<FinancieroModificarCommand>
    {
        public FinancieroModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new FinancieroGenericValidator<FinancieroModificarCommand>());
        }
    }
}
