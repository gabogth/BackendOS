using FluentValidation;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Behaviors
{
    public class CuentaContableTipoModificarValidator : AbstractValidator<CuentaContableTipoModificarCommand>
    {
        public CuentaContableTipoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new CuentaContableTipoGenericValidator<CuentaContableTipoModificarCommand>());
        }
    }
}
