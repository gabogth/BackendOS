using FluentValidation;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Behaviors
{
    public class CuentaContableTipoEliminarValidator : AbstractValidator<CuentaContableTipoEliminarCommand>
    {
        public CuentaContableTipoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
