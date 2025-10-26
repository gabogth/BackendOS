using MediatR;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Queries
{
    public record ObtenerTodosQuery() : IRequest<List<UbicacionActivo>>;
}
