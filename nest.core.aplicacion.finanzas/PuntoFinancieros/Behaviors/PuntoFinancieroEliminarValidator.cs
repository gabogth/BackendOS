using FluentValidation;
using nest.core.aplicacion.finanzas.PuntoFinancieros.Commands;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Behaviors
{
    public class PuntoFinancieroEliminarValidator : AbstractValidator<PuntoFinancieroEliminarCommand>
    {
        public PuntoFinancieroEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");
        }
    }
}
