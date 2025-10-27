using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Behaviors
{
    public class RegistroAsistenciaModificarValidator : AbstractValidator<RegistroAsistenciaModificarCommand>
    {
        public RegistroAsistenciaModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es obligatorio.");

            Include(new RegistroAsistenciaGenericValidator<RegistroAsistenciaModificarCommand>());
        }
    }
}
