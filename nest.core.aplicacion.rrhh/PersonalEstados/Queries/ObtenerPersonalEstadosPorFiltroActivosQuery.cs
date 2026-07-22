using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Queries;

public record ObtenerPersonalEstadosPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
