using FluentValidation;
using nest.core.aplicacion.rrhh.Horarios.Commands;

namespace nest.core.aplicacion.rrhh.Horarios.Behaviors
{
    public class HorarioModificarValidator : AbstractValidator<HorarioModificarCommand>
    {
        public HorarioModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es obligatorio.");

            Include(new HorarioGenericValidator<HorarioModificarCommand>());
        }
    }
}
