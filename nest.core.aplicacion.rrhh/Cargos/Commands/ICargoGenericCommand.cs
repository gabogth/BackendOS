using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Commands
{
    public interface ICargoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        bool Estado { get; }
    }
}
