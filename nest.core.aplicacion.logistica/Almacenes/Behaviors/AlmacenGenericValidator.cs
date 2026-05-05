using FluentValidation;
using nest.core.aplicacion.logistica.Almacenes.Commands;

namespace nest.core.aplicacion.rrhh.Cargos.Behaviors
{
    public class AlmacenGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IAlmacenGenericCommand
    {
        public AlmacenGenericValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder los 200 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre corto no puede exceder los 9 caracteres.");

            RuleFor(x => x.latitud)
                .NotEmpty().WithMessage("La latitud es obligatoria.");

            RuleFor(x => x.lonitud)
                .NotEmpty().WithMessage("La longitud es obligatoria.");

            RuleFor(x => x.Activo)
                .NotEmpty().WithMessage("El campo activo es obligatorio.");

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("La dirección es obligatoria.");

            RuleFor(x => x.DistritoId)
                .NotEmpty().WithMessage("El distrito es obligatorio.");
        }
    }
}
