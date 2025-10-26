using MediatR;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.aplicacion.patrimonial.Activos.Queries
{
    public record ObtenerTodosQuery() : IRequest<List<Activo>>;
}
