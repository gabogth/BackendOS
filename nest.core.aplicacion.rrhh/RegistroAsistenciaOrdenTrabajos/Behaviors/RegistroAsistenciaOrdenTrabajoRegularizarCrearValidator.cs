using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Behaviors
{
    public class RegistroAsistenciaOrdenTrabajoRegularizarCrearValidator : AbstractValidator<RegistroAsistenciaOrdenTrabajoRegularizarCrearCommand>
    {
        public RegistroAsistenciaOrdenTrabajoRegularizarCrearValidator()
        {
            RuleFor(x => x.EmpresaId).GreaterThan(0).WithMessage("El Id de la empresa es obligatorio.");
            RuleFor(x => x.PersonalId).GreaterThan(0).WithMessage("El Id del personal es obligatorio.");
            RuleFor(x => x.EventoTipo).IsInEnum().WithMessage("El tipo de evento es obligatorio y debe ser válido.");
        }
    }
}
