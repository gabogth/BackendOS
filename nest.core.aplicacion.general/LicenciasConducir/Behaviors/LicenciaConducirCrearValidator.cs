using FluentValidation;
using nest.core.aplicacion.general.LicenciasConducir.Commands;

namespace nest.core.aplicacion.general.LicenciasConducir.Behaviors
{
    public sealed class LicenciaConducirCrearValidator : AbstractValidator<LicenciaConducirCrearCommand>
    {
        public LicenciaConducirCrearValidator()
        {
            Include(new LicenciaConducirGenericValidator<LicenciaConducirCrearCommand>());
        }
    }
}
