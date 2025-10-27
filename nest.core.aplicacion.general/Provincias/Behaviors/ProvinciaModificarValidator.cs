using FluentValidation;
using nest.core.aplicacion.general.Provincias.Commands;

namespace nest.core.aplicacion.general.Provincias.Behaviors
{
    public class ProvinciaModificarValidator : AbstractValidator<ProvinciaModificarCommand>
    {
        public ProvinciaModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a cero.");
            Include(new ProvinciaGenericValidator<ProvinciaModificarCommand>());
        }
    }
}
