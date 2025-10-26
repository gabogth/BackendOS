using FluentValidation;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Behaviors
{
    public class MantenimientoTipoCrearValidator : AbstractValidator<MantenimientoTipoCrearCommand>
    {
        public MantenimientoTipoCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(200).WithMessage("El nombre no debe exceder 200 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no debe exceder 50 caracteres.");
        }
    }
}
