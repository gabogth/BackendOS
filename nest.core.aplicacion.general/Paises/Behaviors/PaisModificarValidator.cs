using FluentValidation;
using nest.core.aplicacion.general.Paises.Commands;

namespace nest.core.aplicacion.general.Paises.Behaviors
{
    public class PaisModificarValidator : AbstractValidator<PaisModificarCommand>
    {
        public PaisModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a cero.");
            Include(new PaisGenericValidator<PaisModificarCommand>());
        }
    }
}
