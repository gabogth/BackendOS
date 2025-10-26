using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.Departamentos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<Departamento>>, IQueryBase;
}
