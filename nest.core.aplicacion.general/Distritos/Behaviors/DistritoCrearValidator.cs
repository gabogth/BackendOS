using FluentValidation;
using nest.core.aplicacion.general.Distritos.Commands;

namespace nest.core.aplicacion.general.Distritos.Behaviors
{
    public class DistritoCrearValidator : AbstractValidator<DistritoCrearCommand>
    {
        public DistritoCrearValidator()
        {
            Include(new DistritoGenericValidator<DistritoCrearCommand>());
        }
    }
}
