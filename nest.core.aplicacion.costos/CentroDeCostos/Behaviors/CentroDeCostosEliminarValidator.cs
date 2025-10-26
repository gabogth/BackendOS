using FluentValidation;
using nest.core.aplicacion.costos.CentroDeCostos.Commands;

namespace nest.core.aplicacion.costos.CentroDeCostos.Behaviors
{
    public class CentroDeCostosEliminarValidator : AbstractValidator<CentroDeCostosEliminarCommand>
    {
        public CentroDeCostosEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
