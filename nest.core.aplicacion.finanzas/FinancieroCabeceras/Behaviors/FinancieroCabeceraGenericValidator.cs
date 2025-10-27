using FluentValidation;
using nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Behaviors
{
    public class FinancieroCabeceraGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IFinancieroCabeceraGenericCommand
    {
        public FinancieroCabeceraGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId es requerido.");
            RuleFor(x => x.PuntoFinancieroId)
                .GreaterThan(0).WithMessage("El punto financiero es requerido.");
            RuleFor(x => x.Numero)
                .GreaterThan(0).WithMessage("El número es requerido.");
            RuleFor(x => x.OrigenFinancieroId)
                .GreaterThan((short)0).WithMessage("El origen financiero es requerido.");
            RuleFor(x => x.TerceroGenId)
                .GreaterThan(0).WithMessage("El tercero generador es requerido.");
            RuleFor(x => x.DocumentoTipoGenId)
                .GreaterThan(0).WithMessage("El tipo de documento generador es requerido.");
            RuleFor(x => x.SerieDocumentoGen)
                .NotEmpty().WithMessage("La serie del documento es requerida.")
                .MaximumLength(20).WithMessage("La serie no puede superar los 20 caracteres.");
            RuleFor(x => x.NumeroDocumentoGen)
                .NotEmpty().WithMessage("El número del documento es requerido.")
                .MaximumLength(50).WithMessage("El número no puede superar los 50 caracteres.");
            RuleFor(x => x.Comentarios)
                .MaximumLength(500).WithMessage("Los comentarios no pueden superar los 500 caracteres.");
        }
    }
}
