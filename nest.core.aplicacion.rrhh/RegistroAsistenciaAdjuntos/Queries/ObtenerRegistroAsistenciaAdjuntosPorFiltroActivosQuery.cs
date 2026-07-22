using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Queries;

public record ObtenerRegistroAsistenciaAdjuntosPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
