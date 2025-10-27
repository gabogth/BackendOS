using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Behaviors
{
    public class RegistroAsistenciaPoliticaGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IRegistroAsistenciaPoliticaGenericCommand
    {
        public RegistroAsistenciaPoliticaGenericValidator()
        {
        RuleFor(x => x.EmpresaId)
            .GreaterThan(0).WithMessage("La empresa es obligatoria.");
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        RuleFor(x => x.NombreCorto)
            .NotEmpty().WithMessage("El nombre corto es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre corto no puede exceder 100 caracteres.");
        RuleFor(x => x.Descripcion)
            .MaximumLength(500).WithMessage("La descripción no puede exceder 500 caracteres.");
        RuleFor(x => x.MinutosTardanzaIngreso)
            .GreaterThanOrEqualTo(0).WithMessage("Los minutos de tardanza deben ser mayores o iguales a 0.");
        RuleFor(x => x.MinutosExtra)
            .GreaterThanOrEqualTo(0).WithMessage("Los minutos extra deben ser mayores o iguales a 0.");
        RuleFor(x => x.MinutosExtraEntrada)
            .GreaterThanOrEqualTo(0).WithMessage("Los minutos extra de entrada deben ser mayores o iguales a 0.");
        }
    }
}
