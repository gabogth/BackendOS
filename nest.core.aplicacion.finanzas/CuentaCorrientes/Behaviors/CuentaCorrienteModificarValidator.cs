using FluentValidation;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Commands;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Generics;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Behaviors
{
    public class CuentaCorrienteModificarValidator : AbstractValidator<CuentaCorrienteModificarCommand>
    {
        public CuentaCorrienteModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new CuentaCorrienteGenericValidator<CuentaCorrienteModificarCommand>());
        }
    }
}
