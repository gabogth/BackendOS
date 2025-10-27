using FluentValidation;
using nest.core.aplicacion.costos.CentroDeCostos.Commands;

namespace nest.core.aplicacion.costos.CentroDeCostos.Behaviors
{
    public class CentroDeCostosGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICentroDeCostosGenericCommand
    {
        public CentroDeCostosGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId es requerido.");
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(200).WithMessage("El nombre no puede superar los 200 caracteres.");
            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(100).WithMessage("El nombre corto no puede superar los 100 caracteres.");
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("El código es requerido.")
                .MaximumLength(50).WithMessage("El código no puede superar los 50 caracteres.");
            When(x => x.PadreId.HasValue, () =>
            {
                RuleFor(x => x.PadreId!.Value)
                    .GreaterThan(0).WithMessage("El identificador del padre debe ser mayor a 0.");
            });
        }
    }
}
