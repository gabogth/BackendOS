using FluentValidation;
using nest.core.aplicacion.finanzas.CuentaCorriente.Commands;

namespace nest.core.aplicacion.finanzas.CuentaCorriente.Behaviors
{
    public class CuentaCorrienteCrearValidator : AbstractValidator<CuentaCorrienteCrearCommand>
    {
        public CuentaCorrienteCrearValidator()
        {
            Include(new CuentaCorrienteGenericValidator<CuentaCorrienteCrearCommand>());
        }
    }
}
