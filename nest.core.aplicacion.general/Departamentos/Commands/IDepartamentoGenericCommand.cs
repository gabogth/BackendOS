using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.Departamentos.Commands
{
    public interface IDepartamentoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        int PaisId { get; }
    }
}
