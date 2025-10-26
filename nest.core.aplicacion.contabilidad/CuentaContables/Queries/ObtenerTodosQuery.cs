using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<CuentaContable>>, IQueryBase;
}
