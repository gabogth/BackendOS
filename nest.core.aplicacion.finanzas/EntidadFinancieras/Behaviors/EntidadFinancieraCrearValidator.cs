using FluentValidation;
using nest.core.aplicacion.finanzas.EntidadFinancieras.Commands;

namespace nest.core.aplicacion.finanzas.EntidadFinancieras.Behaviors
{
    public class EntidadFinancieraCrearValidator : AbstractValidator<EntidadFinancieraCrearCommand>
    {
        public EntidadFinancieraCrearValidator()
        {
            Include(new EntidadFinancieraGenericValidator<EntidadFinancieraCrearCommand>());
        }
    }
}
