using FluentValidation;
using nest.core.aplicacion.general.LicenciasConducir.Commands;

namespace nest.core.aplicacion.general.LicenciasConducir.Behaviors
{
    public sealed class LicenciaConducirModificarValidator : AbstractValidator<LicenciaConducirModificarCommand>
    {
        public LicenciaConducirModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((byte)0).WithMessage("El identificador es requerido.");
            Include(new LicenciaConducirGenericValidator<LicenciaConducirModificarCommand>());
        }
    }
}
