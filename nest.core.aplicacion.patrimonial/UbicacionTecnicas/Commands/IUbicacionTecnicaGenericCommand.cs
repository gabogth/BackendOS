using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands
{
    public interface IUbicacionTecnicaGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        bool Activo { get; }
        int? TerceroId { get; }
        long? PadreId { get; }
    }
}
