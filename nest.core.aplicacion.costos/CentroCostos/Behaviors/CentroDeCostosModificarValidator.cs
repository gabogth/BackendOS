using FluentValidation;
using nest.core.aplicacion.costos.CentroCostos.Commands;

namespace nest.core.aplicacion.costos.CentroCostos.Behaviors
{
    public class CentroDeCostosModificarValidator : AbstractValidator<CentroDeCostosModificarCommand>
    {
        public CentroDeCostosModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new CentroDeCostosGenericValidator<CentroDeCostosModificarCommand>());
        }
    }
}
