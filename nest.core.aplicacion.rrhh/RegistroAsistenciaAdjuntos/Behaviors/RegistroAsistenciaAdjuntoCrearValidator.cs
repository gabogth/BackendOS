using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Behaviors
{
    public class RegistroAsistenciaAdjuntoCrearValidator : AbstractValidator<RegistroAsistenciaAdjuntoCrearCommand>
    {
        public RegistroAsistenciaAdjuntoCrearValidator()
        {
            Include(new RegistroAsistenciaAdjuntoGenericValidator<RegistroAsistenciaAdjuntoCrearCommand>());
        }
    }
}
