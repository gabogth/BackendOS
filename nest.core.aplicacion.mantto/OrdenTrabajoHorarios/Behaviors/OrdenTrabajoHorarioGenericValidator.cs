using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Behaviors
{
    public class OrdenTrabajoHorarioGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IOrdenTrabajoHorarioGenericCommand
    {
        public OrdenTrabajoHorarioGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("El identificador de la empresa es obligatorio.");

            RuleFor(x => x.OrdenTrabajoCabeceraId)
                .GreaterThan(0).WithMessage("La cabecera de la orden de trabajo es obligatoria.");

            RuleFor(x => x.PersonalId)
                .GreaterThan(0).WithMessage("El personal es obligatorio.");

            RuleFor(x => x.HorarioCabeceraId)
                .GreaterThan(0).WithMessage("El horario cabecera es obligatorio.");

            RuleFor(x => x.Fecha)
                .Must(fecha => fecha != default)
                .WithMessage("La fecha es obligatoria.");
        }
    }
}
