using FluentValidation;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Behaviors
{
    public class EstructuraOrganizacionalTipoCrearValidator : AbstractValidator<EstructuraOrganizacionalTipoCrearCommand>
    {
        public EstructuraOrganizacionalTipoCrearValidator()
        {
            Include(new EstructuraOrganizacionalTipoGenericValidator<EstructuraOrganizacionalTipoCrearCommand>());
        }
    }
}
