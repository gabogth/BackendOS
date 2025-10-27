using FluentValidation;
using nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Behaviors
{
    public class FinancieroCabeceraCrearValidator : AbstractValidator<FinancieroCabeceraCrearCommand>
    {
        public FinancieroCabeceraCrearValidator()
        {
            Include(new FinancieroCabeceraGenericValidator<FinancieroCabeceraCrearCommand>());
        }
    }
}
