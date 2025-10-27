using FluentValidation;
using nest.core.aplicacion.costos.CentroCostos.Commands;

namespace nest.core.aplicacion.costos.CentroCostos.Behaviors
{
    public class CentroDeCostosCrearValidator : AbstractValidator<CentroDeCostosCrearCommand>
    {
        public CentroDeCostosCrearValidator()
        {
            Include(new CentroDeCostosGenericValidator<CentroDeCostosCrearCommand>());
        }
    }
}
