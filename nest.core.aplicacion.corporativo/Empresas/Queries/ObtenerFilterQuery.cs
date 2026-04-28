using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using nest.core.aplicacion.utils.Queries;

namespace nest.core.aplicacion.corporativo.Empresas.Queries
{
    public sealed record ObtenerFilterQuery(
        DataSourceLoadOptionsBase LoadOptions
    ) : IRequest<LoadResult>, IQueryBase;
}
