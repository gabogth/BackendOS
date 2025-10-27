using FluentValidation;
using nest.core.aplicacion.general.Sexos.Commands;

namespace nest.core.aplicacion.general.Sexos.Behaviors
{
    public class SexoModificarValidator : AbstractValidator<SexoModificarCommand>
    {
        public SexoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((byte)0).WithMessage("El identificador es requerido.");
            Include(new SexoGenericValidator<SexoModificarCommand>());
        }
    }
}
