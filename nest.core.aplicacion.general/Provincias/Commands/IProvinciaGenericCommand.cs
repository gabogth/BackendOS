using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general.Provincias.Commands
{
    public interface IProvinciaGenericCommand : ICommandBase
    {
        string Nombre { get; }
        int DepartamentoId { get; }
    }
}
