using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<CuentaCorriente>>, IQueryBase;
}
