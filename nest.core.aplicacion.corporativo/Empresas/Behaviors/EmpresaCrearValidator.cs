using FluentValidation;
using nest.core.aplicacion.corporativo.Empresas.Commands;

namespace nest.core.aplicacion.corporativo.Empresas.Behaviors
{
    public class EmpresaCrearValidator : AbstractValidator<EmpresaCrearCommand>
    {
        public EmpresaCrearValidator()
        {
            Include(new EmpresaGenericValidator<EmpresaCrearCommand>());
        }
    }
}
