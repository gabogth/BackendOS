using FluentValidation;
using nest.core.aplicacion.finanzas.OrigenFinancieros.Commands;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Behaviors
{
    public class OrigenFinancieroCrearValidator : AbstractValidator<OrigenFinancieroCrearCommand>
    {
        public OrigenFinancieroCrearValidator()
        {
            Include(new OrigenFinancieroGenericValidator<OrigenFinancieroCrearCommand>());
        }
    }
}
