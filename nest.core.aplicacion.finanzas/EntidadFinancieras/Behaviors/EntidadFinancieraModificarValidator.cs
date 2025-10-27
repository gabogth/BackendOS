using FluentValidation;
using nest.core.aplicacion.finanzas.EntidadFinancieras.Commands;

namespace nest.core.aplicacion.finanzas.EntidadFinancieras.Behaviors
{
    public class EntidadFinancieraModificarValidator : AbstractValidator<EntidadFinancieraModificarCommand>
    {
        public EntidadFinancieraModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new EntidadFinancieraGenericValidator<EntidadFinancieraModificarCommand>());
        }
    }
}
