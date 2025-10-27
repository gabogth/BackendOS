using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Behaviors
{
    public class RegistroAsistenciaCrearValidator : AbstractValidator<RegistroAsistenciaCrearCommand>
    {
        public RegistroAsistenciaCrearValidator()
        {
            Include(new RegistroAsistenciaGenericValidator<RegistroAsistenciaCrearCommand>());
        }
    }
}
