using FluentValidation;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Commands;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Behaviors
{
    public class FinancieroDetalleModificarValidator : AbstractValidator<FinancieroDetalleModificarCommand>
    {
        public FinancieroDetalleModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new FinancieroDetalleGenericValidator<FinancieroDetalleModificarCommand>());
        }
    }
}
