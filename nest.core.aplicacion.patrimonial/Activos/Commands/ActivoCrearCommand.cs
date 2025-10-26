using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.aplicacion.patrimonial.Activos.Commands
{
    public record ActivoCrearCommand(
        int EmpresaId,
        long? ProductoLoteId,
        string Nombre,
        string? Descripcion,
        int? DepreciacionMeses,
        int? CentroDeCostosId,
        string? ImagenUrl,
        int? TerceroId
    ) : IRequest<Activo>, ICommandBase;
}
