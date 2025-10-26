using FluentValidation;
using nest.core.aplicacion.security.Formularios.Commands;

namespace nest.core.aplicacion.security.Formularios.Behaviors;

public class FormularioCrearValidator : AbstractValidator<FormularioCrearCommand>
{
    public FormularioCrearValidator()
    {
        RuleFor(x => x.ModuloId)
            .GreaterThan(0).WithMessage("El módulo es obligatorio.");
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        RuleFor(x => x.NombreCorto)
            .NotEmpty().WithMessage("El nombre corto es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre corto no puede exceder 100 caracteres.");
        RuleFor(x => x.Controlador)
            .NotEmpty().WithMessage("El controlador es obligatorio.")
            .MaximumLength(150).WithMessage("El controlador no puede exceder 150 caracteres.");
        RuleFor(x => x.Action)
            .NotEmpty().WithMessage("La acción es obligatoria.")
            .MaximumLength(150).WithMessage("La acción no puede exceder 150 caracteres.");
        RuleFor(x => x.ClaimType)
            .NotEmpty().WithMessage("El claim es obligatorio.")
            .MaximumLength(200).WithMessage("El claim no puede exceder 200 caracteres.");
        RuleFor(x => x.Icono)
            .MaximumLength(100).WithMessage("El icono no puede exceder 100 caracteres.");
        RuleFor(x => x.Descripcion)
            .MaximumLength(500).WithMessage("La descripción no puede exceder 500 caracteres.");
        RuleFor(x => x.Orden)
            .GreaterThanOrEqualTo((short)0).WithMessage("El orden debe ser mayor o igual a 0.");
    }
}
