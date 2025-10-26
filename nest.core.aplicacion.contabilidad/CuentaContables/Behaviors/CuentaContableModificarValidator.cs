using FluentValidation;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Behaviors
{
    public class CuentaContableModificarValidator : AbstractValidator<CuentaContableModificarCommand>
    {
        public CuentaContableModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new CuentaContableCrearValidator());
        }
    }
}
