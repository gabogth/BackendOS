using FluentValidation;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Behaviors
{
    public class DocumentoIdentidadTipoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IDocumentoIdentidadTipoGenericCommand
    {
        public DocumentoIdentidadTipoGenericValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no puede exceder los 50 caracteres.");
        }
    }
}
