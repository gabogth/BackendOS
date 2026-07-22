using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.Cargos.Queries;

public record ObtenerCargosPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
