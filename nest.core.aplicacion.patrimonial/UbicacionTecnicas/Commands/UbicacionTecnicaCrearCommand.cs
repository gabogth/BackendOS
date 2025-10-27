using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands
{
    public record UbicacionTecnicaCrearCommand(
        int EmpresaId,
        string Nombre,
        bool Activo,
        int? TerceroId,
        long? PadreId
    ) : IRequest<UbicacionTecnica>, IUbicacionTecnicaGenericCommand;
}
