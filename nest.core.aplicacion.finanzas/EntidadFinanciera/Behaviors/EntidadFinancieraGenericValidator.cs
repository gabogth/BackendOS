using FluentValidation;
using nest.core.aplicacion.finanzas.EntidadFinanciera.Commands;

namespace nest.core.aplicacion.finanzas.EntidadFinanciera.Behaviors
{
    public class EntidadFinancieraGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IEntidadFinancieraGenericCommand
    {
        public EntidadFinancieraGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId es requerido.");
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(200).WithMessage("El nombre no puede superar los 200 caracteres.");
            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(100).WithMessage("El nombre corto no puede superar los 100 caracteres.");
        }
    }
}
