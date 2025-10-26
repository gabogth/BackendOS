using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Behaviors
{
    public class OrdenServicioCabeceraEliminarValidator : AbstractValidator<OrdenServicioCabeceraEliminarCommand>
    {
        public OrdenServicioCabeceraEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");
        }
    }
}
