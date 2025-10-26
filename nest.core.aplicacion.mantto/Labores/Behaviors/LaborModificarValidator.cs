using FluentValidation;
using nest.core.aplicacion.mantto.Labores.Commands;

namespace nest.core.aplicacion.mantto.Labores.Behaviors
{
    public class LaborModificarValidator : AbstractValidator<LaborModificarCommand>
    {
        public LaborModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");

            Include(new LaborCrearValidator());
        }
    }
}
