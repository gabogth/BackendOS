using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.CentroCostos.Commands
{
    public sealed record CentroDeCostosModificarCommand(
        int Id,
        int EmpresaId,
        string Nombre,
        string NombreCorto,
        string Codigo,
        bool EsFinal,
        bool Activo,
        int? PadreId
    ) : IRequest<CentroDeCostos>, ICentroDeCostosGenericCommand;
}
