using FluentValidation;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Behaviors
{
    public class CuentaContableCrearValidator : AbstractValidator<CuentaContableCrearCommand>
    {
        public CuentaContableCrearValidator()
        {
            Include(new CuentaContableGenericValidator<CuentaContableCrearCommand>());
        }
    }
}
