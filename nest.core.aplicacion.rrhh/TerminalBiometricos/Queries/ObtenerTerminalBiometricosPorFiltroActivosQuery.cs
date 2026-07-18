using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Queries;

public record ObtenerTerminalBiometricosPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
