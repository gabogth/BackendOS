using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Commands
{
    public interface IPersonalEstadoGenericCommand : ICommandBase
    {
        string Nombre { get; }
    }
}
