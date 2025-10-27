using FluentValidation;
using nest.core.aplicacion.costos.CentroDeCostos.Commands;

namespace nest.core.aplicacion.costos.CentroDeCostos.Behaviors
{
    public class CentroDeCostosCrearValidator : AbstractValidator<CentroDeCostosCrearCommand>
    {
        public CentroDeCostosCrearValidator()
        {
            Include(new CentroDeCostosGenericValidator<CentroDeCostosCrearCommand>());
        }
    }
}
