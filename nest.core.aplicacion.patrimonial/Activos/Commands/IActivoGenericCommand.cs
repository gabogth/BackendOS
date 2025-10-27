using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.aplicacion.patrimonial.Activos.Commands
{
    public interface IActivoGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        long? ProductoLoteId { get; }
        string Nombre { get; }
        string? Descripcion { get; }
        int? DepreciacionMeses { get; }
        int? CentroDeCostosId { get; }
        string? ImagenUrl { get; }
        int? TerceroId { get; }
    }
}
