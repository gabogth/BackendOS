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
        }
    }
}
