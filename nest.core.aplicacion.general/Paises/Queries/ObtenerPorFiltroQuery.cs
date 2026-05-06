using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using nest.core.aplicacion.utils.Queries;

namespace nest.core.aplicacion.general.Paises.Queries
{
    public sealed record ObtenerPorFiltroQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>, IQueryBase;
}
