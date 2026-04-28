using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.security.Roles.Queries;

public record ObtenerRolesFilterQuery(
    DataSourceLoadOptionsBase LoadOptions
) : IRequest<LoadResult>;
