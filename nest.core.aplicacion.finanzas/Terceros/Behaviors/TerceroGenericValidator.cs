using FluentValidation;
using nest.core.aplicacion.finanzas.Terceros.Commands;

namespace nest.core.aplicacion.finanzas.Terceros.Behaviors
{
    public class TerceroGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ITerceroGenericCommand
    {
        public TerceroGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId debe ser mayor a 0.");

            RuleFor(x => x.DocumentoIdentidadTipoFinancieroId)
                .GreaterThan((byte)0).WithMessage("DocumentoIdentidadTipoFinancieroId debe ser mayor a 0.");

            RuleFor(x => x.DocumentoIdentidadFinanciero)
                .NotEmpty().WithMessage("El documento de identidad financiero es requerido.")
                .MaximumLength(20).WithMessage("El documento de identidad financiero debe tener como máximo 20 caracteres.");

            RuleFor(x => x.RazonSocial)
                .NotEmpty().WithMessage("La razón social es requerida.")
                .MaximumLength(200).WithMessage("La razón social debe tener como máximo 200 caracteres.");

            RuleFor(x => x.DireccionFiscal)
                .NotEmpty().WithMessage("La dirección fiscal es requerida.")
                .MaximumLength(250).WithMessage("La dirección fiscal debe tener como máximo 250 caracteres.");

            RuleFor(x => x.CuentaContablePorCobrarId)
                .GreaterThan(0).WithMessage("La cuenta contable por cobrar debe ser mayor a 0.");

            RuleFor(x => x.CuentaContablePorPagarId)
                .GreaterThan(0).WithMessage("La cuenta contable por pagar debe ser mayor a 0.");
        }
    }
}
