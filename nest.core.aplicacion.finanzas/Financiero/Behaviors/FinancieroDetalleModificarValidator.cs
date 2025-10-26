using FluentValidation;
using nest.core.aplicacion.finanzas.Financiero.Commands;

namespace nest.core.aplicacion.finanzas.Financiero.Behaviors
{
    public class FinancieroDetalleModificarValidator : AbstractValidator<FinancieroDetalleModificarCommand>
    {
        public FinancieroDetalleModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            RuleFor(x => x.FinancieroCabeceraId)
                .GreaterThan(0).WithMessage("La cabecera es requerida.");
            Include(new FinancieroDetalleEntradaValidator());
        }
    }
}
