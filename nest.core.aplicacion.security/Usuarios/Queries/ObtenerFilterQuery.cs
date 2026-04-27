using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using nest.core.aplicacion.utils.Queries;

namespace nest.core.aplicacion.security.Usuarios.Queries
{
    public sealed record ObtenerFilterQuery(
        DataSourceLoadOptionsBase loadOptions
    ) : IRequest<LoadResult>, IQueryBase;
}
