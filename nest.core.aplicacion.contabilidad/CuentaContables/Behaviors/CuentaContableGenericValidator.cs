using FluentValidation;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Behaviors
{
    public class CuentaContableGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICuentaContableGenericCommand
    {
        public CuentaContableGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId es requerido.");
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(200).WithMessage("El nombre no puede superar los 200 caracteres.");
            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(100).WithMessage("El nombre corto no puede superar los 100 caracteres.");
            RuleFor(x => x.ES)
                .NotEmpty().WithMessage("El código ES es requerido.")
                .MaximumLength(20).WithMessage("El código ES no puede superar los 20 caracteres.");
            RuleFor(x => x.CuentaContableTipoId)
                .GreaterThan(0).WithMessage("El tipo de cuenta contable es requerido.");
            RuleFor(x => x.Nivel)
                .GreaterThanOrEqualTo(0).WithMessage("El nivel debe ser mayor o igual a 0.");
            When(x => x.PadreId.HasValue, () =>
            {
                RuleFor(x => x.PadreId!.Value)
                    .GreaterThan(0).WithMessage("El identificador del padre debe ser mayor a 0.");
            });
        }
    }
}
