using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<CuentaContableTipo>>, IQueryBase;
}
