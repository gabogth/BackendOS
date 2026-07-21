using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;

public record ObtenerPersonalCargoExternosPorFiltroDataSourceQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
