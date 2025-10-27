using FluentValidation;
using nest.core.aplicacion.rrhh.Horarios.Commands;

namespace nest.core.aplicacion.rrhh.Horarios.Behaviors
{
    public class HorarioEliminarValidator : AbstractValidator<HorarioEliminarCommand>
    {
        public HorarioEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es obligatorio.");
        }
    }
}
