using FluentValidation;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Behaviors
{
    public class HorarioDetalleEventoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IHorarioDetalleEventoGenericCommand
    {
        public HorarioDetalleEventoGenericValidator()
        {
        RuleFor(x => x.EmpresaId)
            .GreaterThan(0).WithMessage("La empresa es obligatoria.");

        RuleFor(x => x.HorarioDetalleId)
            .GreaterThan(0).WithMessage("El detalle de horario es obligatorio.");

        RuleFor(x => x.Hora)
            .NotEmpty().WithMessage("La hora es obligatoria.");

        RuleFor(x => x.VentanaMin)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.VentanaMax)
            .GreaterThanOrEqualTo(0);
        }
    }
}
