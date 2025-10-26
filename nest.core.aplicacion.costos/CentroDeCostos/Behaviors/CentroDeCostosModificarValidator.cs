using FluentValidation;
using nest.core.aplicacion.costos.CentroDeCostos.Commands;

namespace nest.core.aplicacion.costos.CentroDeCostos.Behaviors
{
    public class CentroDeCostosModificarValidator : AbstractValidator<CentroDeCostosModificarCommand>
    {
        public CentroDeCostosModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new CentroDeCostosCrearValidator());
        }
    }
}
