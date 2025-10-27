using FluentValidation;
using nest.core.aplicacion.rrhh.Horarios.Commands;

namespace nest.core.aplicacion.rrhh.Horarios.Behaviors
{
    public class HorarioGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IHorarioGenericCommand
    {
        public HorarioGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es obligatoria.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.");

            RuleFor(x => x.Detalles)
                .NotNull().WithMessage("Debe registrar al menos un detalle.");

            RuleForEach(x => x.Detalles)
                .SetValidator(new HorarioDetalleValidator());
        }
    }
}
