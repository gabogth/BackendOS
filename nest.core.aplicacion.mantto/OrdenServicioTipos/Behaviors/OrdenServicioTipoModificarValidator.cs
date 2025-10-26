using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Behaviors
{
    public class OrdenServicioTipoModificarValidator : AbstractValidator<OrdenServicioTipoModificarCommand>
    {
        public OrdenServicioTipoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((short)0).WithMessage("El identificador debe ser mayor a 0.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(200).WithMessage("El nombre no debe exceder 200 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no debe exceder 50 caracteres.");
        }
    }
}
