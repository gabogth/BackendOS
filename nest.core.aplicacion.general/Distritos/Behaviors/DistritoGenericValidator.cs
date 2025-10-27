using FluentValidation;
using nest.core.aplicacion.general.Distritos.Commands;

namespace nest.core.aplicacion.general.Distritos.Behaviors
{
    public class DistritoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IDistritoGenericCommand
    {
        public DistritoGenericValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("Nombre es requerido.");
            RuleFor(x => x.ProvinciaId)
                .NotEmpty().WithMessage("Provincia es requerida.");
        }
    }
}
