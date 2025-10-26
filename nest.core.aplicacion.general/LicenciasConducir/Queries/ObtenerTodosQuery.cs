using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.LicenciasConducir.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<LicenciaConducir>>, IQueryBase;
}
