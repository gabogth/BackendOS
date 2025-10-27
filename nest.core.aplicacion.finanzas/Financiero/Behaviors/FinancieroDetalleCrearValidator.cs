using FluentValidation;
using nest.core.aplicacion.finanzas.Financiero.Commands;

namespace nest.core.aplicacion.finanzas.Financiero.Behaviors
{
    public class FinancieroDetalleCrearValidator : AbstractValidator<FinancieroDetalleCrearCommand>
    {
        public FinancieroDetalleCrearValidator()
        {
            Include(new FinancieroDetalleGenericValidator<FinancieroDetalleCrearCommand>());
        }
    }
}
