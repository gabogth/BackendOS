using FluentValidation;
using nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Behaviors
{
    public class FinancieroCabeceraModificarValidator : AbstractValidator<FinancieroCabeceraModificarCommand>
    {
        public FinancieroCabeceraModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new FinancieroCabeceraGenericValidator<FinancieroCabeceraModificarCommand>());
        }
    }
}
