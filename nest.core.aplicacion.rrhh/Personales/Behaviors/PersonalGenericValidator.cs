using FluentValidation;
using nest.core.aplicacion.rrhh.Personales.Commands;

namespace nest.core.aplicacion.rrhh.Personales.Behaviors
{
    public class PersonalGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IPersonalGenericCommand
    {
        public PersonalGenericValidator()
        {
        RuleFor(x => x.EmpresaId)
            .GreaterThan(0).WithMessage("La empresa es obligatoria.");

        RuleFor(x => x.ContratoCabeceraId)
            .GreaterThan(0).WithMessage("El contrato es obligatorio.");

        RuleFor(x => x.HorarioCabeceraId)
            .GreaterThan(0).WithMessage("El horario es obligatorio.");

        RuleFor(x => x.PersonalEstadoId)
            .GreaterThan((byte)0).WithMessage("El estado es obligatorio.");

        RuleFor(x => x.RegistroAsistenciaPoliticaId)
            .GreaterThan(0).WithMessage("La política de asistencia es obligatoria.");
        }
    }
}
