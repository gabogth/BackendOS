using FluentValidation;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Behaviors
{
    public class EstructuraOrganizacionalCrearValidator : AbstractValidator<EstructuraOrganizacionalCrearCommand>
    {
        public EstructuraOrganizacionalCrearValidator()
        {
            Include(new EstructuraOrganizacionalGenericValidator<EstructuraOrganizacionalCrearCommand>());
        }
    }
}
