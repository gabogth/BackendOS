using FluentValidation;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Commands;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Behaviors
{
    public class FinancieroDetalleGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IFinancieroDetalleGenericCommand
    {
        public FinancieroDetalleGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId es requerido.");
            RuleFor(x => x.FinancieroCabeceraId)
                .GreaterThan(0).WithMessage("La cabecera es requerida.");
            RuleFor(x => x.Item)
                .GreaterThan((short)0).WithMessage("El item es requerido.");
            RuleFor(x => x.TerceroId)
                .GreaterThan(0).WithMessage("El tercero es requerido.");
            RuleFor(x => x.DocumentoTipoId)
                .GreaterThan(0).WithMessage("El tipo de documento es requerido.");
            RuleFor(x => x.SerieDocumento)
                .NotEmpty().WithMessage("La serie es requerida.")
                .MaximumLength(20).WithMessage("La serie no puede superar los 20 caracteres.");
            RuleFor(x => x.NumeroDocumento)
                .NotEmpty().WithMessage("El número es requerido.")
                .MaximumLength(50).WithMessage("El número no puede superar los 50 caracteres.");
            RuleFor(x => x.Concepto)
                .NotEmpty().WithMessage("El concepto es requerido.")
                .MaximumLength(500).WithMessage("El concepto no puede superar los 500 caracteres.");
            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto debe ser mayor a 0.");
            RuleFor(x => x.ES)
                .NotEmpty().WithMessage("El campo ES es requerido.")
                .MaximumLength(5).WithMessage("El campo ES no puede superar los 5 caracteres.");
        }
    }
}
