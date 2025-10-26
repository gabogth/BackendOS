using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands
{
    public record UbicacionTecnicaModificarCommand(
        long Id,
        int EmpresaId,
        string Nombre,
        bool Activo,
        int? TerceroId,
        long? PadreId
    ) : IRequest<UbicacionTecnica>, ICommandBase;
}
