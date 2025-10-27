using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands
{
    public interface IOrdenTrabajoPersonalGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        long OrdenTrabajoCabeceraId { get; }
        int PersonaId { get; }
        bool EsLider { get; }
    }
}
