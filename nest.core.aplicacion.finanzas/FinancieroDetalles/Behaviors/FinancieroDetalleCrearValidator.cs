using FluentValidation;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Commands;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Behaviors
{
    public class FinancieroDetalleCrearValidator : AbstractValidator<FinancieroDetalleCrearCommand>
    {
        public FinancieroDetalleCrearValidator()
        {
            Include(new FinancieroDetalleGenericValidator<FinancieroDetalleCrearCommand>());
        }
    }
}
