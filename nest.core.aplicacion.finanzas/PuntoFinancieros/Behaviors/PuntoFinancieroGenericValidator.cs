using FluentValidation;
using nest.core.aplicacion.finanzas.PuntoFinancieros.Commands;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Behaviors
{
    public class PuntoFinancieroGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IPuntoFinancieroGenericCommand
    {
        public PuntoFinancieroGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId debe ser mayor a 0.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre debe tener como máximo 150 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto debe tener como máximo 50 caracteres.");
        }
    }
}
