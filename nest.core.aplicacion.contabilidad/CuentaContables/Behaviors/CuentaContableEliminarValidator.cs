using FluentValidation;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Behaviors
{
    public class CuentaContableEliminarValidator : AbstractValidator<CuentaContableEliminarCommand>
    {
        public CuentaContableEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
