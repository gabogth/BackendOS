using FluentValidation;
using nest.core.aplicacion.finanzas.Monedas.Commands;

namespace nest.core.aplicacion.finanzas.Monedas.Behaviors
{
    public class MonedaGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IMonedaGenericCommand
    {
        public MonedaGenericValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(200).WithMessage("El nombre no puede superar los 200 caracteres.");
            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no puede superar los 50 caracteres.");
            RuleFor(x => x.Prefix)
                .MaximumLength(10).WithMessage("El prefijo no puede superar los 10 caracteres.");
            RuleFor(x => x.Sufix)
                .MaximumLength(10).WithMessage("El sufijo no puede superar los 10 caracteres.");
            RuleFor(x => x.Simbolo)
                .NotEmpty().WithMessage("El símbolo es requerido.")
                .MaximumLength(5).WithMessage("El símbolo no puede superar los 5 caracteres.");
        }
    }
}
