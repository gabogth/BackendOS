using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Behaviors
{
    public class RegistroAsistenciaAdjuntoModificarValidator : AbstractValidator<RegistroAsistenciaAdjuntoModificarCommand>
    {
        public RegistroAsistenciaAdjuntoModificarValidator()
        {
            Include(new RegistroAsistenciaAdjuntoGenericValidator<RegistroAsistenciaAdjuntoModificarCommand>());
        }
    }
}
