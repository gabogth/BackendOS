using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Queries;

public sealed record ObtenerPorIdQuery(long RegistroAsistenciaId) : IRequest<RegistroAsistenciaAdjunto>, IQueryBase;
