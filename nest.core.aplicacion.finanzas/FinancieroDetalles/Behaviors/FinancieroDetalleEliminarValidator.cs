using FluentValidation;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Commands;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Behaviors
{
    public class FinancieroDetalleEliminarValidator : AbstractValidator<FinancieroDetalleEliminarCommand>
    {
        public FinancieroDetalleEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
