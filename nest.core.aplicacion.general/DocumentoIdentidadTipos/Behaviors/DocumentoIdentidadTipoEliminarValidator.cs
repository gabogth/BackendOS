using FluentValidation;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Behaviors
{
    public sealed class DocumentoIdentidadTipoEliminarValidator : AbstractValidator<DocumentoIdentidadTipoEliminarCommand>
    {
        public DocumentoIdentidadTipoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((byte)0).WithMessage("El identificador es requerido.");
        }
    }
}
