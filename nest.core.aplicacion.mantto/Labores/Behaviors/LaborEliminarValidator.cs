using FluentValidation;
using nest.core.aplicacion.mantto.Labores.Commands;

namespace nest.core.aplicacion.mantto.Labores.Behaviors
{
    public class LaborEliminarValidator : AbstractValidator<LaborEliminarCommand>
    {
        public LaborEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");
        }
    }
}
