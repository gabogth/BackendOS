using FluentValidation;
using nest.core.aplicacion.rrhh.Horarios.Commands;

namespace nest.core.aplicacion.rrhh.Horarios.Behaviors
{
    public class HorarioDetalleValidator : AbstractValidator<HorarioDetalleCommand>
    {
        public HorarioDetalleValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es obligatoria.");

            RuleFor(x => x.DiaSemana)
                .IsInEnum().WithMessage("El día de la semana es obligatorio.");

            RuleFor(x => x.Eventos)
                .NotNull().WithMessage("Debe registrar al menos un evento por día.");

            RuleForEach(x => x.Eventos)
                .SetValidator(new HorarioDetalleEventoValidator());
        }
    }
}
