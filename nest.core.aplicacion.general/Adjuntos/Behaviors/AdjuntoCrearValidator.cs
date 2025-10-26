using FluentValidation;
using nest.core.aplicacion.general.Adjuntos.Commands;

namespace nest.core.aplicacion.general.Adjuntos.Behaviors
{
    public class AdjuntoCrearValidator : AbstractValidator<AdjuntoCrearCommand>
    {
        public AdjuntoCrearValidator()
        {
            RuleFor(x => x.Modulo)
                .IsInEnum().WithMessage("El módulo proporcionado es inválido.");

            RuleFor(x => x.Content)
                .NotNull().WithMessage("El contenido del adjunto es requerido.");

            RuleFor(x => x.FileName)
                .NotEmpty().WithMessage("El nombre del archivo es requerido.")
                .MaximumLength(255).WithMessage("El nombre del archivo no debe exceder 255 caracteres.");

            RuleFor(x => x.Size)
                .GreaterThan(0).WithMessage("El tamaño del archivo debe ser mayor a 0.");
        }
    }
}
