using FluentValidation;
using nest.core.aplicacion.finanzas.Financiero.Commands;

namespace nest.core.aplicacion.finanzas.Financiero.Behaviors
{
    public class FinancieroDetalleGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IFinancieroDetalleGenericCommand
    {
        public FinancieroDetalleGenericValidator()
        {
            RuleFor(x => x.FinancieroCabeceraId)
                .GreaterThan(0).WithMessage("La cabecera es requerida.");
            Include(new FinancieroDetalleEntradaValidator());
        }
    }
}
