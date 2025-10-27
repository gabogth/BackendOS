using FluentValidation;
using nest.core.aplicacion.general.Provincias.Commands;

namespace nest.core.aplicacion.general.Provincias.Behaviors
{
    public class ProvinciaCrearValidator : AbstractValidator<ProvinciaCrearCommand>
    {
        public ProvinciaCrearValidator()
        {
            Include(new ProvinciaGenericValidator<ProvinciaCrearCommand>());
        }
    }
}
