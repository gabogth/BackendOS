using FluentValidation;
using nest.core.aplicacion.patrimonial.Activos.Commands;

namespace nest.core.aplicacion.patrimonial.Activos.Behaviors
{
    public class ActivoModificarValidator : AbstractValidator<ActivoModificarCommand>
    {
        public ActivoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del activo es obligatorio.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("El identificador de la empresa es obligatorio.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del activo es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre del activo no puede superar los 200 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede superar los 500 caracteres.");

            RuleFor(x => x.DepreciacionMeses)
                .GreaterThanOrEqualTo(0).When(x => x.DepreciacionMeses.HasValue)
                .WithMessage("La depreciación debe ser un valor positivo.");
        }
    }
}
