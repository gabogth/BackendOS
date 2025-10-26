using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Sexos.Queries
{
    public sealed record ObtenerPorIdQuery(byte Id) : IRequest<Sexo>, IQueryBase;
}
