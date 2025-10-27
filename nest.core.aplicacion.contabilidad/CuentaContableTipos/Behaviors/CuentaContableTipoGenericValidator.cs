using FluentValidation;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Behaviors
{
    public class CuentaContableTipoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICuentaContableTipoGenericCommand
    {
        public CuentaContableTipoGenericValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no puede superar los 150 caracteres.");
            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no puede superar los 50 caracteres.");
        }
    }
}
