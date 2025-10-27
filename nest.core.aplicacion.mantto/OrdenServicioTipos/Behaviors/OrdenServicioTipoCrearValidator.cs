using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Behaviors
{
    public class OrdenServicioTipoCrearValidator : AbstractValidator<OrdenServicioTipoCrearCommand>
    {
        public OrdenServicioTipoCrearValidator()
        {
            Include(new OrdenServicioTipoGenericValidator<OrdenServicioTipoCrearCommand>());
        }
    }
}
