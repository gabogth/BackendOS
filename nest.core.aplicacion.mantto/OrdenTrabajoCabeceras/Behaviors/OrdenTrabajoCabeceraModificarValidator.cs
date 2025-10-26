using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Behaviors
{
    public class OrdenTrabajoCabeceraModificarValidator : AbstractValidator<OrdenTrabajoCabeceraModificarCommand>
    {
        public OrdenTrabajoCabeceraModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");

            Include(new OrdenTrabajoCabeceraCrearValidator());
        }
    }
}
