using MediatR;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Queries
{
    public record ObtenerActivasQuery() : IRequest<List<UbicacionTecnica>>;
}
