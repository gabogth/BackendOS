using FluentValidation;
using nest.core.aplicacion.general.Paises.Commands;

namespace nest.core.aplicacion.general.Paises.Behaviors
{
    public class PaisCrearValidator : AbstractValidator<PaisCrearCommand>
    {
        public PaisCrearValidator()
        {
            Include(new PaisGenericValidator<PaisCrearCommand>());
        }
    }
}
