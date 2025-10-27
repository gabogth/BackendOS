using FluentValidation;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Commands;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Behaviors
{
    public class CuentaCorrienteEliminarValidator : AbstractValidator<CuentaCorrienteEliminarCommand>
    {
        public CuentaCorrienteEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
