using FluentValidation;
using nest.core.aplicacion.finanzas.EntidadFinanciera.Commands;

namespace nest.core.aplicacion.finanzas.EntidadFinanciera.Behaviors
{
    public class EntidadFinancieraCrearValidator : AbstractValidator<EntidadFinancieraCrearCommand>
    {
        public EntidadFinancieraCrearValidator()
        {
            Include(new EntidadFinancieraGenericValidator<EntidadFinancieraCrearCommand>());
        }
    }
}
