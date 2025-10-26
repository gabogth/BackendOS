using FluentValidation;
using nest.core.aplicacion.general.AdjuntoTipos.Commands;

namespace nest.core.aplicacion.general.AdjuntoTipos.Behaviors
{
    public class AdjuntoTipoCrearValidator : AbstractValidator<AdjuntoTipoCrearCommand>
    {
        public AdjuntoTipoCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(100).WithMessage("El nombre no debe exceder 100 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no debe exceder 50 caracteres.");
        }
    }
}
