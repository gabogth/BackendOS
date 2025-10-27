using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Behaviors
{
    public class RegistroAsistenciaGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IRegistroAsistenciaGenericCommand
    {
        public RegistroAsistenciaGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es obligatoria.");

            RuleFor(x => x.PersonalId)
                .GreaterThan(0).WithMessage("El personal es obligatorio.");

            RuleFor(x => x.Fecha)
                .NotEqual(default(DateTime)).WithMessage("La fecha es obligatoria.");

            RuleFor(x => x.FechaJornal)
                .NotEqual(default(DateOnly)).WithMessage("La fecha de jornal es obligatoria.");

            RuleFor(x => x.DiferenciaMinutos)
                .GreaterThanOrEqualTo(0).WithMessage("La diferencia de minutos no puede ser negativa.");
        }
    }
}
