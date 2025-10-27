using FluentValidation;
using nest.core.aplicacion.rrhh.Horarios.Commands;

namespace nest.core.aplicacion.rrhh.Horarios.Behaviors
{
    public class HorarioDetalleEventoValidator : AbstractValidator<HorarioDetalleEventoCommand>
    {
        public HorarioDetalleEventoValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es obligatoria.");

            RuleFor(x => x.HorarioDetalleId)
                .GreaterThanOrEqualTo(0).WithMessage("El detalle asociado es requerido.");

            RuleFor(x => x.Hora)
                .NotEmpty().WithMessage("La hora del evento es obligatoria.");
        }
    }
}
