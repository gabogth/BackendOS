using FluentValidation;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Behaviors
{
    public sealed class DocumentoIdentidadTipoModificarValidator : AbstractValidator<DocumentoIdentidadTipoModificarCommand>
    {
        public DocumentoIdentidadTipoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((byte)0).WithMessage("El identificador es requerido.");
            Include(new DocumentoIdentidadTipoGenericValidator<DocumentoIdentidadTipoModificarCommand>());
        }
    }
}
