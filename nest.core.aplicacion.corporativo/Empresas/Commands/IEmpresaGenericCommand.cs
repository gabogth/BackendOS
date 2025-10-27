using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.Empresas.Commands
{
    public interface IEmpresaGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        bool Estado { get; }
    }
}
