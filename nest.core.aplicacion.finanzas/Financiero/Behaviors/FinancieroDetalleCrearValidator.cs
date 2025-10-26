using FluentValidation;
using nest.core.aplicacion.finanzas.Financiero.Commands;

namespace nest.core.aplicacion.finanzas.Financiero.Behaviors
{
    public class FinancieroDetalleCrearValidator : AbstractValidator<FinancieroDetalleCrearCommand>
    {
        public FinancieroDetalleCrearValidator()
        {
            RuleFor(x => x.FinancieroCabeceraId)
                .GreaterThan(0).WithMessage("La cabecera es requerida.");
            Include(new FinancieroDetalleEntradaValidator());
        }
    }
}
