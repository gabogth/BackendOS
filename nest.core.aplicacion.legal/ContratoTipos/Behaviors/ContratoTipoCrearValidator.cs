using FluentValidation;
using nest.core.aplicacion.legal.ContratoTipos.Commands;

namespace nest.core.aplicacion.legal.ContratoTipos.Behaviors
{
    public class ContratoTipoCrearValidator : AbstractValidator<ContratoTipoCrearCommand>
    {
        public ContratoTipoCrearValidator()
        {
            Include(new ContratoTipoGenericValidator<ContratoTipoCrearCommand>());
        }
    }
}
