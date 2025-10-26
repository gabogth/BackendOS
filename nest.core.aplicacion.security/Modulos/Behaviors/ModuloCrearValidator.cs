using FluentValidation;
using nest.core.aplicacion.security.Modulos.Commands;

namespace nest.core.aplicacion.security.Modulos.Behaviors;

public class ModuloCrearValidator : AbstractValidator<ModuloCrearCommand>
{
    public ModuloCrearValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        RuleFor(x => x.NombreCorto)
            .NotEmpty().WithMessage("El nombre corto es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre corto no puede exceder 100 caracteres.");
        RuleFor(x => x.Descripcion)
            .MaximumLength(500).WithMessage("La descripción no puede exceder 500 caracteres.");
        RuleFor(x => x.RutaImagen)
            .MaximumLength(300).WithMessage("La ruta de la imagen no puede exceder 300 caracteres.");
        RuleFor(x => x.Action)
            .MaximumLength(150).WithMessage("La acción no puede exceder 150 caracteres.");
        RuleFor(x => x.Controlador)
            .MaximumLength(150).WithMessage("El controlador no puede exceder 150 caracteres.");
    }
}
