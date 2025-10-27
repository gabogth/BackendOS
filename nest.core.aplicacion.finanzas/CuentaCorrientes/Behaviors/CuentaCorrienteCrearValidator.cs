using FluentValidation;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Commands;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Behaviors
{
    public class CuentaCorrienteCrearValidator : AbstractValidator<CuentaCorrienteCrearCommand>
    {
        public CuentaCorrienteCrearValidator()
        {
            Include(new CuentaCorrienteGenericValidator<CuentaCorrienteCrearCommand>());
        }
    }
}
