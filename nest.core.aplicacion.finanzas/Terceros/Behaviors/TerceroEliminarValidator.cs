using FluentValidation;
using nest.core.aplicacion.finanzas.Terceros.Commands;

namespace nest.core.aplicacion.finanzas.Terceros.Behaviors
{
    public class TerceroEliminarValidator : AbstractValidator<TerceroEliminarCommand>
    {
        public TerceroEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");
        }
    }
}
