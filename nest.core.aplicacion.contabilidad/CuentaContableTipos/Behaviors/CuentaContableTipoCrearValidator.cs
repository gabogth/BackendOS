using FluentValidation;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Behaviors
{
    public class CuentaContableTipoCrearValidator : AbstractValidator<CuentaContableTipoCrearCommand>
    {
        public CuentaContableTipoCrearValidator()
        {
            Include(new CuentaContableTipoGenericValidator<CuentaContableTipoCrearCommand>());
        }
    }
}
