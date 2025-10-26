using FluentValidation;
using nest.core.aplicacion.general.LicenciasConducir.Commands;

namespace nest.core.aplicacion.general.LicenciasConducir.Behaviors
{
    public sealed class LicenciaConducirCrearValidator : AbstractValidator<LicenciaConducirCrearCommand>
    {
        public LicenciaConducirCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no puede exceder los 150 caracteres.");

            RuleFor(x => x.Nivel)
                .GreaterThan((byte)0).WithMessage("El nivel debe ser mayor a 0.");
        }
    }
}
