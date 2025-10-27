using FluentValidation;
using nest.core.aplicacion.finanzas.Terceros.Commands;

namespace nest.core.aplicacion.finanzas.Terceros.Behaviors
{
    public class TerceroModificarValidator : AbstractValidator<TerceroModificarCommand>
    {
        public TerceroModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");
            Include(new TerceroGenericValidator<TerceroModificarCommand>());
        }
    }
}
