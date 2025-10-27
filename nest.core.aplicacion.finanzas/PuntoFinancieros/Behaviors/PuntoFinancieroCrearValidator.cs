using FluentValidation;
using nest.core.aplicacion.finanzas.PuntoFinancieros.Commands;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Behaviors
{
    public class PuntoFinancieroCrearValidator : AbstractValidator<PuntoFinancieroCrearCommand>
    {
        public PuntoFinancieroCrearValidator()
        {
            Include(new PuntoFinancieroGenericValidator<PuntoFinancieroCrearCommand>());
        }
    }
}
