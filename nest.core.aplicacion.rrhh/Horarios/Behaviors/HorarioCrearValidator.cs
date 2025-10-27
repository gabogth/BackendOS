using FluentValidation;
using nest.core.aplicacion.rrhh.Horarios.Commands;

namespace nest.core.aplicacion.rrhh.Horarios.Behaviors
{
    public class HorarioCrearValidator : AbstractValidator<HorarioCrearCommand>
    {
        public HorarioCrearValidator()
        {
            Include(new HorarioGenericValidator<HorarioCrearCommand>());
        }
    }
}
